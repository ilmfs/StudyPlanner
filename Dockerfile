
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY StudyPlanner/StudyPlanner.csproj .
RUN dotnet restore StudyPlanner.csproj


COPY StudyPlanner/. .
RUN dotnet publish StudyPlanner.csproj -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .


ENV ASPNETCORE_URLS=http://0.0.0.0:$PORT

ENTRYPOINT ["dotnet", "StudyPlanner.dll"]
