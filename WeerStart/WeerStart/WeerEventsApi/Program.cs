using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Factories;
using WeerEventsApi.Steden.Repositories;
using WeerEventsApi.Facade.Controllers;
using WeerEventsApi.Weerberichten.Managers;
using WeerEventsApi.Weerberichten.Proxies;
using WeerEventsApi.Weerstations.Metingen;
using WeerEventsApi.Weerstations.Managers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMetingLogger>(MetingLoggerFactory.Create(true, true));
builder.Services.AddSingleton<IStadRepository, StadRepository>();
builder.Services.AddSingleton<IStadManager, StadManager>();

builder.Services.AddSingleton<IWeerstationManager, WeerstationManager>();
builder.Services.AddSingleton<IWeerberichtService>(provider =>
{
    var realService = new WeerberichtService();
    return new WeerberichtProxy(realService);
});

builder.Services.AddSingleton<IDomeinController, DomeinController>();

var app = builder.Build();

app.MapGet("/", () => "WEER - WEERsomstandigheden Evalueren En Rapporteren");
app.MapGet("/steden", (IDomeinController dc) => dc.GeefSteden());
app.MapGet("/weerstations", (IDomeinController dc) => dc.GeefWeerstations());
app.MapGet("/metingen", (IDomeinController dc) => dc.GeefMetingen());
app.MapGet("/weerbericht", (IDomeinController dc) => dc.GeefWeerbericht());
app.MapPost("/commands/meting-command", (IDomeinController dc) =>
{
    dc.DoeMetingen();
    return Results.Ok();
});

app.Run();