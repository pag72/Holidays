namespace HolidaySearch;

public class WhenCustomer2Searches
{
    [Fact]
    public void Flight6Hotel5IsReturned()
    {
        var searchParameters = new SearchParameters
        {
            DepartingFrom = new List<string>() { "LTN", "LGW" },
            TravellingTo = "PMI",
            DepartureDate = "2023/06/15",
            Duration = 10
        };

        var holidaySearch = new HolidaySearch(searchParameters);
        var bestMatchingResult = holidaySearch?.Results().First();
        Assert.True(bestMatchingResult != null);
        Assert.True(bestMatchingResult?.Flight?.Id == 6 && bestMatchingResult?.Hotel?.Id == 5);
    }
}
