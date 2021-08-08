FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /build/
COPY . /build/
RUN dotnet publish -c release

FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /root/
COPY --from=0 /build/bin/release/net5.0/publish .
ENTRYPOINT ["dotnet", "RepositoryStats.dll"]