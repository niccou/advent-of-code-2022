namespace AdventOfCode.Tests;

public class CleaningTests
{
    [Theory]
    [InlineData("2-4,6-8", false)]
    [InlineData("2-3,4-5", false)]
    [InlineData("5-7,7-9", false)]
    [InlineData("2-8,3-7", true)]
    [InlineData("6-6,4-6", true)]
    [InlineData("2-6,4-8", false)]
    public void IsFullyContainedShouldReturnExpectedForAssignment(string assignment, bool expectedIsFullyContained)
    {
        bool isFullyContained = assignment.IsFullyContained();

        isFullyContained.Should().Be(expectedIsFullyContained);
    }

    [Theory]
    [InlineData("2-4,6-8", false)]
    [InlineData("2-3,4-5", false)]
    [InlineData("5-7,7-9", true)]
    [InlineData("2-8,3-7", true)]
    [InlineData("6-6,4-6", true)]
    [InlineData("2-6,4-8", true)]
    public void IsOverlapShouldReturnExpectedForAssignment(string assignment, bool expectedIsOverlap)
    {
        bool isOverlap = assignment.IsOverlap();

        isOverlap.Should().Be(expectedIsOverlap);
    }
}