using System.Net.Http.Headers;
using ArrayAndCollections;

public class BusRouteRepository
{
    public static BusRoute[] InitializeRepository()
    {
        return new BusRoute[]
        {
            new BusRoute(40, "Rzeszów", "Kraków"),
            new BusRoute(44, "Rzeszów", "Warszawa"),
            new BusRoute(34, "Kraków", "Warszawa"),
            new BusRoute(52, "Wrocław", "Kraków")
        };
    }
}