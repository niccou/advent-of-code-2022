using System.Text;

namespace AdventOfCode;

public static class SupplyStacks
{
    private static IEnumerable<char> GetCrates(this string input)
    {
        for (var i = 1; i < input.Length - 1; i = i + 4)
        {
            yield return input[i];
        }
    }

    public static string ParseLine(this string input)
        => new string(input.GetCrates().ToArray());

    public static IDictionary<int, Stack<string>> GetStartingCrates(this string[] input)
    {
        var result = new Dictionary<int, Stack<string>>();
        var starting = input
            .TakeWhile(i => !string.IsNullOrEmpty(i))
            .SkipLast(1)
            .Select(ParseLine)
            .ToList();

        for (int row = (starting.Count - 1); row >= 0; row--)
        {
            var rowData = starting[row];

            for (int i = 0; i < rowData.Length; i++)
            {
                if (!result.ContainsKey(i + 1))
                {
                    result[i + 1] = new();
                }

                if (rowData[i] != ' ')
                {
                    result[i + 1].Push(new string(rowData[i], 1));
                }
            }
        }

        return result;
    }

    public static Move[] GetMoves(this string[] input)
        => input.SkipWhile(s => !string.IsNullOrEmpty(s)).Skip(1).Select(GetMove).ToArray();

    public static Move GetMove(this string move)
    {
        var details = move.Replace("move ", "").Replace(" from ", "-").Replace(" to ", "-").Split('-');

        var count = int.Parse(details[0]);
        var from = int.Parse(details[1]);
        var to = int.Parse(details[2]);

        return new(count, from, to);
    }

    public static IDictionary<int, Stack<string>> ProcessCrateMover9000Move(this IDictionary<int, Stack<string>> cargo, Move move)
    {
        for (var i = 1; i <= move.Count; i++)
        {
            if (cargo[move.From].Count > 0)
            {
                cargo[move.To].Push(cargo[move.From].Pop());
            }
        }

        return cargo;
    }

    public static IDictionary<int, Stack<string>> ProcessCrateMover9001Move(this IDictionary<int, Stack<string>> cargo, Move move)
    {
        Stack<string> crateMover9001 = new();
        for (var i = 1; i <= move.Count; i++)
        {
            if (cargo[move.From].Count > 0)
            {
                crateMover9001.Push(cargo[move.From].Pop());
            }
        }

        while (crateMover9001.Count > 0)
        {
            cargo[move.To].Push(crateMover9001.Pop());
        }

        return cargo;
    }

    public static IDictionary<int, Stack<string>> ProcessCrateMover9000Moves(this IDictionary<int, Stack<string>> cargo, Move[] moves)
    {
        foreach (var move in moves)
        {
            cargo = cargo.ProcessCrateMover9000Move(move);
        }
        return cargo;
    }

    public static IDictionary<int, Stack<string>> ProcessCrateMover9001Moves(this IDictionary<int, Stack<string>> cargo, Move[] moves)
    {
        foreach (var move in moves)
        {
            cargo = cargo.ProcessCrateMover9001Move(move);
        }
        return cargo;
    }

    public static string DisplayTopCrates(this IDictionary<int, Stack<string>> cargo)
    {
        StringBuilder sb = new();

        for (var i = 1; i <= cargo.Count; i++)
        {
            if (cargo[i].Count > 0)
            {
                sb.Append(cargo[i].Peek());
            }
        }

        return sb.ToString();

    }
}

public record Move(int Count, int From, int To);