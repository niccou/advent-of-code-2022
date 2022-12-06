// See https://aka.ms/new-console-template for more information
using System.Text;

using AdventOfCode;

Day5();

static void Day1()
{
    var input = System.IO.File.ReadAllLines("src/AdventOfCode/Day1.txt");

    var sumByElf = input.SumByElf();

    var max = sumByElf.Max();

    var sum = sumByElf.OrderDescending().Take(3).Sum();

    StringBuilder sb = new();

    sb
        .AppendLine($"The max is : {max}")
        .AppendLine($"The top three elves sum is : {sum}");

    Console.WriteLine(sb.ToString());
}

static void Day2()
{
    var input = System.IO.File.ReadAllLines("src/AdventOfCode/Day2.txt");

    var totalScore = input.CalculateFinalScore();

    Console.WriteLine($"The total score is {totalScore}");
}

static void Day3()
{
    var input = System.IO.File.ReadAllLines("src/AdventOfCode/Day3.txt");

    var priority = input.GetPriorityForDoubles();
    var badges = input.GetPriorityForBadges();

    Console.WriteLine($"The total priority for doubles is {priority}");
    Console.WriteLine($"The total priority for badges is {badges}");
}

static void Day4()
{
    var input = System.IO.File.ReadAllLines("src/AdventOfCode/Day4.txt");

    var fullyContainedCount = input.FullyContainedCount();
    var overlapCount = input.OverlapCount();

    Console.WriteLine($"The count of fully contained assignments is {fullyContainedCount}");
    Console.WriteLine($"The count of overlap is {overlapCount}");
}

static void Day5()
{
    string[] input = { };

    if (System.IO.File.Exists("src/AdventOfCode/Day5.txt"))
    {
        input = System.IO.File.ReadAllLines("src/AdventOfCode/Day5.txt");
    }
    else
    {
        input = System.IO.File.ReadAllLines("Day5.txt");
    }

    var cargo = input.GetStartingCrates();
    var moves = input.GetMoves();

    var topCrates = cargo.ProcessCrateMover9001Moves(moves).DisplayTopCrates();
    Console.WriteLine($"The crates at the top are {topCrates}");
}

static void Day6()
{
    var input = System.IO.File.ReadAllText("src/AdventOfCode/Day6.txt");

    var packetIndex = input.StartOfPacketIndex();
    var messageIndex = input.StartOfMessageIndex();

    Console.WriteLine($"The packet index is {packetIndex} and the message index is {messageIndex}");
}
