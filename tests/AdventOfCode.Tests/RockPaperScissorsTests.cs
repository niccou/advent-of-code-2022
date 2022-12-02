namespace AdventOfCode.Tests;

public class RockPaperScissorsTests
{
    private readonly List<string> _sample = new(){
        "A Y",
        "B X",
        "C Z"
    };

    [Theory]
    [InlineData("A Y", 8)]
    [InlineData("B X", 1)]
    [InlineData("C Z", 6)]
    public void CalculateScoreForRound(string round, int expectedScore)
    {
        int score = round.CalculateScore();

        score.Should().Be(expectedScore);
    }

    [Fact]
    public void CalculateFinalScore()
    {
        int expectedScore = 15;
        int finalScore = _sample.CalculateFinalScore();

        finalScore.Should().Be(expectedScore);
    }
}