// See https://aka.ms/new-console-template for more information
using System.Text;

using AdventOfCode;

Day2();

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
