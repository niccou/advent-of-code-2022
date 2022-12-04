namespace AdventOfCode;

public static class Cleaning
{
    public static int FullyContainedCount(this IEnumerable<string> assignments)
        => assignments.Where(IsFullyContained).Count();
    
    public static int OverlapCount(this IEnumerable<string> assignments)
        => assignments.Where(IsOverlap).Count();
    
    public static bool IsFullyContained(this string assignment)
    {
        var (firstAsignement, secondAssignment) = assignment.GetAssignments();
        return (firstAsignement.IsSubsetOf(secondAssignment) || secondAssignment.IsSubsetOf(firstAsignement));
    }
    
    public static bool IsOverlap(this string assignment)
    {
        var (firstAsignement, secondAssignment) = assignment.GetAssignments();
        return firstAsignement.Intersect(secondAssignment).Count() > 0;
    }

    private static (HashSet<int> FirstAssignment, HashSet<int> SecondAssignment) GetAssignments(this string assignment)
    {
        var sections = assignment.Split(',','-').Select(section => int.Parse(section)).ToList();

        return (Sections(sections[0], sections[1]),Sections(sections[2], sections[3]));
    }

    private static HashSet<int> Sections(int start, int end)
    {
        HashSet<int> sections = new();

        for (int i = start; i <= end; i++)
        {
            sections.Add(i);
        }

        return sections;
    }
}