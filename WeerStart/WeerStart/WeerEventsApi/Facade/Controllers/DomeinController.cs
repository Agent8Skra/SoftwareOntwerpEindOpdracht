using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Logging;
using WeerEventsApi.Weerstations.Managers;
using WeerEventsApi.Weerberichten.Managers;
namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;
    private readonly IWeerstationManager _stationManager;
    private readonly IMetingLogger _logger;
    private readonly IWeerberichtService _weerberichtService;

    public DomeinController(IStadManager stadManager, IWeerstationManager stationManager, IMetingLogger logger, IWeerberichtService weerberichtService)
    {
        _stadManager = stadManager;
        _stationManager = stationManager;
        _logger = logger;
        _weerberichtService = weerberichtService;
    }

    public IEnumerable<StadDto> GeefSteden() => _stadManager.GeefSteden().Select(s => new StadDto
    {
        Naam = s.Naam,
        Beschrijving = s.Beschrijving,
        GekendVoor = s.GekendVoor
    });

    public IEnumerable<WeerStationDto> GeefWeerstations() => _stationManager.GetStations().Select(ws => new WeerStationDto
    {
        Type = ws.Type,
        StadNaam = ws.Locatie.Naam
    });

    public IEnumerable<MetingDto> GeefMetingen() => _stationManager.GetMetingen().Select(m => new MetingDto
    {
        Moment = m.Moment,
        Waarde = m.Waarde,
        Eenheid = m.Eenheid.ToString(),
        StadNaam = m.Locatie.Naam
    });

    public void DoeMetingen()
    {
        _stationManager.DoeMetingen();
        foreach (var m in _stationManager.GetMetingen())
        {
            _logger.Log($"{m.Moment} - {m.Waarde} {m.Eenheid} in {m.Locatie.Naam}");
        }
    }

    public WeerBerichtDto GeefWeerbericht()
    {
        var bericht = _weerberichtService.GenerateReport(_stationManager.GetMetingen());
        return new WeerBerichtDto
        {
            Moment = bericht.CreatedAt,
            Inhoud = bericht.Content
        };
    }
}