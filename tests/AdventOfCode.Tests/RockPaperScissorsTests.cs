namespace AdventOfCode.Tests;

public class RockPaperScissorsTests
{
    private readonly List<string> _sample = new(){
        "A Y",
        "B X",
        "C Z"
    };

    [Theory]
    [InlineData("A Y", 4)]
    [InlineData("B X", 1)]
    [InlineData("C Z", 7)]
    public void CalculateScoreForRound(string round, int expectedScore)
    {
        int score = round.CalculateScore();

        score.Should().Be(expectedScore);
    }

    [Fact]
    public void CalculateFinalScore()
    {
        int expectedScore = 12;
        int finalScore = _sample.CalculateFinalScore();

        finalScore.Should().Be(expectedScore);
    }
}