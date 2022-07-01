namespace HolidaySearch;

public class WhenCustomer3Searches
{
    [Fact]
    public void Flight7Hotel6IsReturned()
    {
        var searchParameters = new SearchParameters
        {
            DepartingFrom = null,
            TravellingTo = "LPA",
            DepartureDate = "2022/11/10",
            Duration = 14
        };

        var holidaySearch = new HolidaySearch(searchParameters);
        var bestMatchingResult = holidaySearch?.Results().First();
        Assert.True(bestMatchingResult != null);
        Assert.True(bestMatchingResult?.Flight?.Id == 7 && bestMatchingResult?.Hotel?.Id == 6);
    }
}
