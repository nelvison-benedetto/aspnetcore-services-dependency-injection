
using MyServiceLibrary_Contracts;
namespace MyServicesLibrary;

public class CitiesService : ICitiesService, IDisposable
{
    private List<string> _cities;
    private Guid _serviceIstanceId;
    public Guid SerrviceIstanceId {
        get { return _serviceIstanceId; }
    }
    public CitiesService()
    {
        _serviceIstanceId = Guid.NewGuid();
        _cities = new List<string>()
        {
            "New York",
            "Los Angeles",
            "Chicago",
            "Houston",
            "Phoenix"
        };
    }
    
    public List<string> GetCities()
    {
        return _cities;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
