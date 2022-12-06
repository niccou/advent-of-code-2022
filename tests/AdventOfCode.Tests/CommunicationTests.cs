namespace AdventOfCode.Tests;

public class CommunicationTests
{
    [Theory]
    [InlineData("m", false)]
    [InlineData("mj", false)]
    [InlineData("mjq", false)]
    [InlineData("mjqj", false)]
    [InlineData("jqjp", false)]
    [InlineData("qjpq", false)]
    [InlineData("jpqm", true)]
    public void IsStartOfPacketMarkerShouldReturnExpectedResponse(string characters, bool expectedResponse)
    {
        characters.IsStartOfPacketMarker().Should().Be(expectedResponse);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void StartOfPackageShouldReturnIndex(string input, int expectedIndex)
    {
        input.StartOfPacketIndex().Should().Be(expectedIndex);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void StartOfMessageShouldReturnIndex(string input, int expectedIndex)
    {
        input.StartOfMessageIndex().Should().Be(expectedIndex);
    }
}
