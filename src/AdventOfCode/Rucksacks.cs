namespace AdventOfCode;

public static class Rucksacks
{
    private static readonly int _referenceCode = (int)'a';
    private static readonly int _offset = 1;
    private static readonly int _capitalizedReferenceCode = (int)'A';
    private static readonly int _capitalizedOffset = 27;

    public static int Priority(this char item)
        => (int)item - item.ReferenceCode() + item.OffSet();

    public static char GetCommonItem(this string rucksack)
    {
        HashSet<char> firstCompartment = new(rucksack.Substring(0, rucksack.Length / 2));
        HashSet<char> secondCompartment = new(rucksack.Substring(rucksack.Length / 2));

        return firstCompartment.Intersect(secondCompartment).Single();
    }

    public static int GetPriorityForDoubles(this IEnumerable<string> rucksacks)
        => rucksacks.Select(GetCommonItem).Select(Priority).Sum();

    public static int GetPriorityForBadges(this IEnumerable<string> rucksacks)
    {
        int sum = 0;
        for (int i = 0; i < rucksacks.Count(); i = i + 3)
        {
            sum += rucksacks.Skip(i).Take(3).GetBadgeItem().Priority();
        }
        return sum;
    }

    public static char GetBadgeItem(this IEnumerable<string> rucksacks)
    {
        var itemsByRucksack = rucksacks.Select(rucksack => new HashSet<char>(rucksack)).ToList();

        var firstRucksack = itemsByRucksack[0];
        var secondRucksack = itemsByRucksack[1];
        var thirdRucksack = itemsByRucksack[2];

        return firstRucksack.Intersect(secondRucksack).Intersect(thirdRucksack).Single();
    }

    private static bool IsCapitalized(this char item)
        => (int)item <= (int)'Z';

    private static int ReferenceCode(this char item)
        => item.IsCapitalized() ? _capitalizedReferenceCode : _referenceCode;

    private static int OffSet(this char item)
        => item.IsCapitalized() ? _capitalizedOffset : _offset;
}