namespace HolidaySearch;

public class WhenCustomer1Searches
{
    private SearchParameters? searchParameters;

    [Fact]
    public void Flight2Hotel9IsReturned()
    {
        this.searchParameters = new SearchParameters
        {
            DepartingFrom = new List<string>() { "MAN" },
            TravellingTo = "AGP",
            DepartureDate = "2023/07/01",
            Duration = 7
        };

        var holidaySearch = new HolidaySearch(searchParameters);
        var bestMatchingResult = holidaySearch?.Results().First();
        Assert.True(bestMatchingResult != null);
        Assert.True(bestMatchingResult?.Flight?.Id == 2 && bestMatchingResult?.Hotel?.Id == 9);
    }

}
