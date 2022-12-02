namespace AdventOfCode;

public static class RockPaperScissors
{
    public const string Rock = "A";
    public const string Paper = "B";
    public const string Scissors = "C";
    public const string LoseRound = "X";
    public const string DrawRound = "Y";
    public const string WinRound = "Z";
    public const int RockPoints = 1;
    public const int PaperPoints = 2;
    public const int ScissorsPoints = 3;
    public const int Lose = 0;
    public const int Draw = 3;
    public const int Win = 6;

    private static int ShapePoints(string playerShape)
        => playerShape switch
        {
            Paper => PaperPoints,
            Rock => RockPoints,
            _ => ScissorsPoints
        };

    private static string PlayerShape(string elfShape, string expectedResult)
        => expectedResult switch
        {
            LoseRound => elfShape switch
            {
                Rock => Scissors,
                Paper => Rock,
                _ => Paper
            },
            WinRound => elfShape switch
            {
                Rock => Paper,
                Paper => Scissors,
                _ => Rock
            },
            _ => elfShape
        };

    private static (string ElfShape, string ExpectedResult) GetElfShapeAndExpectedResult(this string round)
    {
        var shapes = round.Split(' ');

        return (shapes[0], shapes[1]);
    }

    public static int CalculateScore(this string round)
    {
        var (elfShape, expectedResult) = round.GetElfShapeAndExpectedResult();
        var playerShape = PlayerShape(elfShape, expectedResult);
        return ShapePoints(playerShape) + RoundResult(expectedResult);
    }

    private static int RoundResult(string expectedResult)
        => expectedResult switch
        {
            WinRound => Win,
            DrawRound => Draw,
            _ => Lose
        };

    public static int CalculateFinalScore(this IEnumerable<string> rounds)
        => rounds.Sum(CalculateScore);
}