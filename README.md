# RepositoryStats

![RepositoryStats Output](https://github.com/amscotti/RepositoryStats/blob/master/RepositoryStats?raw=true)

A simple application using `LibGit2Sharp` to display stats of commits from a repository. The output is a list of users with the number of commits, dates for the first and last commit, and the number of days detween the dates sorted by the first commit date. This is an F# incarnation of a similar project I have done in different languages. I will say, thay this is my favorite version.

## Reasoning
Beside being a fun project, the idea was first created to be able to get a better understanding of a Repository that I was working on for a company. For this particular repository I had a suspicion that it had a high turnover of developers throughout its lifespan, and looking at the commit history I was able to provide data to my theory.

This output also can help give a better undertsanding of a lifespan of a repository, along with identifying key developers that have worked on the project and could be valuable resources when exploring areas of the code.
# Running with Dotnet
To run, `dotnet run <PATH TO REPO>`

# Docker
Build image with, `docker build . -t repository_stats`

To run you have to mount the folder with the repository into the container, 
`docker run -v <PATH TO REPO>:/repo repository_stats /repo`