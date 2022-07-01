using HolidaySearch.Model;
using HolidaySearch.Data;

namespace HolidaySearch
{
	public class HolidaySearch
	{
		private SearchParameters search;
		private readonly FlightRepository flightData;
		private readonly HotelRepository hotelData;

		public HolidaySearch(SearchParameters searchParameters)
		{
			search = searchParameters;
			flightData = new FlightRepository();
			hotelData = new HotelRepository();
		}

		public IEnumerable<Result> Results()
        {
            List<Result> results = new();
            List<Flight> flights = flightData.Flights;

            flights = FilterByDepartingFrom(flights);
            flights = FilterByTravellingTo(flights);
            flights = FilterByDepartureDate(flights);

            List<Hotel> hotels = hotelData.Hotels;
            foreach (var flight in flights)
            {
                List<Hotel> hotelsForFlight = FilterHotelsByFlight(hotels, flight);

                foreach (var hotel in hotelsForFlight)
                {
                    results.Add(new Result
                    {
                        TotalPrice = $"£{flight.Price + (hotel.PricePerNight * hotel.Nights)}.00",
                        Flight = flight,
                        Hotel = hotel
                    });
                }
            }

            return results.Any() ? results.OrderBy(x => x.Flight?.Price + (x.Hotel?.PricePerNight * x.Hotel?.Nights)) : results;
        }

        private List<Hotel> FilterHotelsByFlight(List<Hotel> hotels, Flight flight)
        {
            return hotels.FindAll(x => x.LocalAirports.Contains(flight.To)
                && DateTime.Compare(x.ArrivalDate.Date, flight.DepartureDate.Date) == 0
                && x.Nights == search.Duration);
        }

        private List<Flight> FilterByDepartureDate(List<Flight> flights)
        {
            return DateTime.TryParse(search.DepartureDate, out DateTime parsedDate) ? flights.FindAll(x => DateTime.Compare(x.DepartureDate.Date, parsedDate.Date) == 0) : new List<Flight>();
        }

        private List<Flight> FilterByTravellingTo(List<Flight> flights)
        {
            return flights.FindAll(x => search.TravellingTo != null && search.TravellingTo.Contains(x.To));
        }

        private List<Flight> FilterByDepartingFrom(List<Flight> flights)
        {
            if (search.DepartingFrom?.Any() == true)
            {
                flights = flights.FindAll(x => search.DepartingFrom.Contains(x.From));
            }

            return flights;
        }
    }
}

