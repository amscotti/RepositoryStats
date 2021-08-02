open System
open LibGit2Sharp

type UserCommit =
    { Email: string
      Commits: int
      FirstCommit: DateTime
      LastCommit: DateTime }

let getRepository (path: string) : Repository option =
    try
        new Repository(path) |> Some
    with
    | ex ->
        eprintfn "Error: %s" ex.Message
        None

let createUserCommit (email: string, commits: seq<Commit>) : UserCommit =
    let dates =
        commits
        |> Seq.map (fun c -> c.Committer.When.Date)
        |> Seq.sort

    { Email = email
      Commits = Seq.length commits
      FirstCommit = Seq.head dates
      LastCommit = Seq.last dates }

let formatUserCommit
    { Email = email
      Commits = commit
      FirstCommit = first
      LastCommit = last }
    : string =
    $"{email, -50}\t{commit, 10}\t{first, 10:d}\t{last, 10:d}\t{(last - first).TotalDays, 5}"

let printRepository (repo: Repository) =
    printfn "%-50s\t%10s\t%10s\t%10s\t%5s" "Email" "Commits" "First" "Last" "Days"

    repo.Commits
    |> Seq.groupBy (fun c -> c.Author.Email)
    |> Seq.map createUserCommit
    |> Seq.sortBy (fun c -> c.FirstCommit)
    |> Seq.iter (formatUserCommit >> (printfn "%s"))

[<EntryPoint>]
let main argv =
    match argv |> Array.tryHead |> Option.bind getRepository with
    | Some repo ->
        printRepository repo
        0
    | None ->
        printfn "Error loading repository"
        1
