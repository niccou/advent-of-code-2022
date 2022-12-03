namespace AdventOfCode.Tests;

public class RucksacksTests
{
    private readonly List<string> _sample = new(){
        "vJrwpWtwJgWrhcsFMMfFFhFp",
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
        "PmmdzqPrVvPwwTWBwg",
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
        "ttgJtRGJQctTZtZT",
        "CrZsJsPPZsGzwwsLwLmpwMDw",
    };

    [Theory]
    [InlineData('a', 1)]
    [InlineData('b', 2)]
    [InlineData('c', 3)]
    [InlineData('d', 4)]
    [InlineData('e', 5)]
    [InlineData('f', 6)]
    [InlineData('g', 7)]
    [InlineData('h', 8)]
    [InlineData('i', 9)]
    [InlineData('j', 10)]
    [InlineData('k', 11)]
    [InlineData('l', 12)]
    [InlineData('m', 13)]
    [InlineData('n', 14)]
    [InlineData('o', 15)]
    [InlineData('p', 16)]
    [InlineData('q', 17)]
    [InlineData('r', 18)]
    [InlineData('s', 19)]
    [InlineData('t', 20)]
    [InlineData('u', 21)]
    [InlineData('v', 22)]
    [InlineData('w', 23)]
    [InlineData('x', 24)]
    [InlineData('y', 25)]
    [InlineData('z', 26)]
    [InlineData('A', 27)]
    [InlineData('B', 28)]
    [InlineData('C', 29)]
    [InlineData('D', 30)]
    [InlineData('E', 31)]
    [InlineData('F', 32)]
    [InlineData('G', 33)]
    [InlineData('H', 34)]
    [InlineData('I', 35)]
    [InlineData('J', 36)]
    [InlineData('K', 37)]
    [InlineData('L', 38)]
    [InlineData('M', 39)]
    [InlineData('N', 40)]
    [InlineData('O', 41)]
    [InlineData('P', 42)]
    [InlineData('Q', 43)]
    [InlineData('R', 44)]
    [InlineData('S', 45)]
    [InlineData('T', 46)]
    [InlineData('U', 47)]
    [InlineData('V', 48)]
    [InlineData('W', 49)]
    [InlineData('X', 50)]
    [InlineData('Y', 51)]
    [InlineData('Z', 52)]
    public void GetItemPriorityShouldReturnExpectedPriority(char item, int expectedPriority)
    {
        int priority = item.Priority();

        priority.Should().Be(expectedPriority);
    }

    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
    [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
    [InlineData("ttgJtRGJQctTZtZT", 't')]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
    public void GetCommonItemShouldReturnItem(string rucksack, char expectedItem)
    {
        char item = rucksack.GetCommonItem();

        item.Should().Be(expectedItem);
    }

    [Fact]
    public void GetBadgeItemForFirstGroupShouldReturnExpectedItem()
    {
        char badge = _sample.Take(3).GetBadgeItem();

        badge.Should().Be('r');
    }

    [Fact]
    public void GetBadgeItemForSecongGroupShouldReturnExpectedItem()
    {
        char badge = _sample.TakeLast(3).GetBadgeItem();

        badge.Should().Be('Z');
    }

    [Fact]
    public void GetPriorityForBadgesShouldReturnExpected()
    {
        int priority = _sample.GetPriorityForBadges();

        priority.Should().Be(70);
    }
}