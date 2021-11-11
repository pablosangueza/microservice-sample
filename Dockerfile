FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS devbase
WORKDIR /src

FROM devbase as build
COPY . .
RUN dotnet build ./Sales.Microservice/ -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sales.Microservice/Sales.Microservice.csproj" -c Release -o /app

FROM base as final
RUN sed 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/' /etc/ssl/openssl.cnf > /etc/ssl/openssl.cnf.changed && mv /etc/ssl/openssl.cnf.changed /etc/ssl/openssl.cnf
WORKDIR /app

COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sales.Microservice.dll"]