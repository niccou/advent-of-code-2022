namespace AdventOfCode.Tests;

public class CaloriesTests
{
    private readonly List<string> _sample = new(){
        "1000",
        "2000",
        "3000",
        "",
        "4000",
        "",
        "5000",
        "6000",
        "",
        "7000",
        "8000",
        "9000",
        "",
        "10000",
    };

    [Fact]
    public void SumCaloriesShouldReturnTheSumForEachElf()
    {
        List<int> expected = new()
        {
            6_000, 4_000, 11_000, 24_000, 10_000
        };

        List<int> sumByElves = _sample.SumByElf();

        sumByElves.Should().BeEquivalentTo(expected);
    }
}