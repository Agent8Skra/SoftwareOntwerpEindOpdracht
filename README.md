# WeerEventsApi

Simuleert en rapporteert weersomstandigheden in steden op basis van virtuele weerstations.


## Build, Run & Test

### Build
Open "WeerStart.sln" in **Visual Studio 2022+** met .NET 9 SDK geïnstalleerd.

### Run
1. Stel "WeerEventsApi" in als **Startup Project**
2. Start met "F5" of klik de groene play knop
3. API draait op: "http://localhost:5008"
4. Request het gewenste commando in "ApiCalls.http"

### Test
Gebruik het bestand "ApiCalls.http" met de **REST Client extensie** in VS Code of test manueel via Postman:

http
GET    http://localhost:5008/
GET    http://localhost:5008/steden
GET    http://localhost:5008/weerstations
POST   http://localhost:5008/commands/meting-command
GET    http://localhost:5008/metingen
GET    http://localhost:5008/weerbericht
