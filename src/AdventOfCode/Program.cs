// See https://aka.ms/new-console-template for more information
using System.Text;

using AdventOfCode;

var day1Input = System.IO.File.ReadAllLines("src/AdventOfCode/Day1.txt");

var sumByElf = day1Input.SumByElf();

var max = sumByElf.Max();

var sum = sumByElf.OrderDescending().Take(3).Sum();

StringBuilder sb = new();

sb
    .AppendLine($"The max is : {max}")
    .AppendLine($"The top three elves sum is : {sum}");

Console.WriteLine(sb.ToString());
