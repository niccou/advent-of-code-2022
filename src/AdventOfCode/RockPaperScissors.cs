namespace AdventOfCode;

public static class RockPaperScissors
{
    public const string ElfRock = "A";
    public const string ElfPaper = "B";
    public const string ElfScissors = "C";
    public const string PlayerRock = "X";
    public const string PlayerPaper = "Y";
    public const string PlayerScissors = "Z";
    public const int RockPoints = 1;
    public const int PaperPoints = 2;
    public const int ScissorsPoints = 3;
    public const int Lose = 0;
    public const int Draw = 3;
    public const int Win = 6;

    private static int RoundResult(string elfShape, string playerShape)
        => elfShape switch
        {
            ElfRock => playerShape switch {
                PlayerPaper => Win,
                PlayerRock => Draw,
                _ => Lose
            },
            ElfPaper => playerShape switch {
                PlayerScissors => Win,
                PlayerPaper => Draw,
                _ => Lose
            },
            ElfScissors => playerShape switch {
                PlayerRock => Win,
                PlayerScissors => Draw,
                _ => Lose
            },
            _ => Lose
        };

    private static int ShapePoints(string playerShape)
        => playerShape switch{
            PlayerPaper => PaperPoints,
            PlayerRock => RockPoints,
            PlayerScissors => ScissorsPoints,
            _ => 0
        };

    private static (string ElfShape, string PlayerShape) GetRoundShapes(this string round)
    {
        var shapes = round.Split(' ');

        return (shapes[0], shapes[1]);
    }

    public static int CalculateScore(this string round)
    {
        var (elfShape, playerShape) = round.GetRoundShapes();

        return ShapePoints(playerShape) + RoundResult(elfShape, playerShape);
    }

    public static int CalculateFinalScore(this IEnumerable<string> rounds)
        => rounds.Sum(CalculateScore);
}