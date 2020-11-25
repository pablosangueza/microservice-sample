** Run App Locally**
dotnet build .\Sales.Microservice\
dotnet run --project .\Sales.Microservice\
** Create Docker container **
docker build -f ./Dockerfile -t sales-microservice .
** Run Docker Container **
docker run -p 8080:80 sales-microservice -it  