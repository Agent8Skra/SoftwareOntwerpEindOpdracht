# Gemaakt door Kyllian Rasschaert
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

```http
GET    http://localhost:5008/
GET    http://localhost:5008/steden
GET    http://localhost:5008/weerstations
POST   http://localhost:5008/commands/meting-command
GET    http://localhost:5008/metingen
GET    http://localhost:5008/weerbericht
```
### Known issues
-Façade: DomeinController bevat te veel afhankelijkheden
De DomeinController heeft 4 servicesen dit maakt het moeilijker testbaar.
  
Oplossing: Gebruik een service layer.

-JsonLoggerDecorator logt geen correcte objectstructuur
Momenteel logt de JsonLoggerDecorator een custom string als tekst, in plaats van een gestructureerd JSON-object.

Oplossing: Maak de logger beter zodat hij objecten als JSON kan serialiseren

### Informeel klassendiagram

[Facade]
------------------------------------
DomeinController : IDomeinController
>+ GeefSteden() : IEnumerable<StadDto>
>+ GeefWeerstations() : IEnumerable<WeerStationDto>
>+ GeefMetingen() : IEnumerable<MetingDto>
>+ GeefWeerbericht() : WeerBerichtDto
>+ DoeMetingen()

Gebruik:
> IStadManager
>>StadManager
>>StadRepository
>>>>leest steden uit steden.json

>IWeerstationManager
>>WeerstationManager
>>>genereert 12 Weerstation instanties (types: Wind, Neerslag...)

>IWeerberichtService
>>WeerberichtProxy
>>>WeerberichtService

>IMetingLogger
>>MetingLogger
>>>JsonLoggerDecorator
>>>>XmlLoggerDecorator


[Core Domeinmodellen]
------------------------------------
Stad
>string Naam
>string Beschrijving
>string GekendVoor

Weerstation
>string Type
>Stad Locatie
>List<Meting> Metingen
>>Meting DoeMeting()

Meting
>DateTime Moment
>double Waarde
>Eenheid Eenheid
>Stad Locatie

Enum Eenheid
>KilometerPerUur
>MillimeterPerVierkanteMeterPerUur
>GradenCelsius
>HectoPascal

Weerbericht
>DateTime CreatedAt
>string Content


[Patronen]
------------------------------------

[Decorator]
>IMetingLogger
>>MetingLogger
>>JsonLoggerDecorator : IMetingLogger
>>>XmlLoggerDecorator : IMetingLogger

[Proxy]
>IWeerberichtService
>WeerberichtService
>>WeerberichtProxy (cache 1 min, lazy loading)


[DTO's]
------------------------------------
StadDto
>string Naam
>string Beschrijving
>string GekendVoor

WeerStationDto
>string Type
>string StadNaam

MetingDto
>DateTime Moment
>double Waarde
>string Eenheid
>string StadNaam

WeerBerichtDto
>DateTime Moment
>string Inhoud
