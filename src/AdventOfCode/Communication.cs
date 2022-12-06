namespace AdventOfCode;

public static class Communication
{
    public static bool IsStartOfPacketMarker(this string input)
        => new HashSet<char>(input).Count == 4;

    public static int StartOfPacketIndex(this string input)
    {
        for (var i = 4; i <= input.Length; i++)
        {
            if (input.Substring(i - 4, 4).IsStartOfPacketMarker())
            {
                return i;
            }
        }
        return -1;
    }

    public static int StartOfMessageIndex(this string input)
    {
        for (var i = 14; i <= input.Length; i++)
        {
            if (input.Substring(i - 14, 14).IsStartOfMessageMarker())
            {
                return i;
            }
        }
        return -1;
    }

    private static bool IsStartOfMessageMarker(this string input)
        => new HashSet<char>(input).Count == 14;
}