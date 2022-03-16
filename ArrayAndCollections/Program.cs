
using ArrayAndCollections;

BusRoute[] allRoutes = BusRouteRepository.InitializeRepository();

Console.WriteLine("Where do you want to go to?");
var location = Console.ReadLine();

var findBusTo = BusRoute.FindBusTo(allRoutes, location);

Console.WriteLine(findBusTo is not null ? $"You can use route {findBusTo.Number}" : $"No bus to location: {location}");