namespace AdventOfCode;

public static class Calories
{
    public static List<int> SumByElf(this IEnumerable<string> carriedCalories)
    {
        List<int> sumByElf = new();
        
        int sum = 0;

        foreach (var carried in carriedCalories)
        {
            if (string.IsNullOrWhiteSpace(carried) && sum != 0)
            {
                sumByElf.Add(sum);
                sum = 0;
                continue;
            }
            sum += int.Parse(carried);
        }

        sumByElf.Add(sum);

        return sumByElf;
    }
}