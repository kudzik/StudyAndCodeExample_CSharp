namespace ArrayAndCollections;

public class BusRoute
{
    public BusRoute(int number, string? origin, string? destination)
    {
        Number = number;
        Origin = origin;
        Destination = destination;
    }

    public int Number { get; }
    public string? Origin { get; }
    public string? Destination { get; }

    public override string ToString()
    {
        return $"{Number} : {Origin} => {Destination}";
    }

    public static BusRoute? FindBusTo(BusRoute[] busRoutes, string? location)
        => busRoutes.FirstOrDefault(r => r.Origin == location || r.Destination == location);

    public static BusRoute? FindBusToArray(BusRoute[] busRoutes, string? location)
        => Array.Find(busRoutes, r => r.Origin == location || r.Destination == location);

}