namespace AdventOfCode.Tests;

public class SupplyStacksTests
{
    private readonly string[] _sample = new[] {
        "    [D]    ",
        "[N] [C]    ",
        "[Z] [M] [P]",
        " 1   2   3 ",
        "",
        "move 1 from 2 to 1",
        "move 3 from 1 to 3",
        "move 2 from 2 to 1",
        "move 1 from 1 to 2"
    };

    private readonly Stack<string> _expectedStartingColumn1 = new();

    private readonly Stack<string> _expectedStartingColumn2 = new();

    private readonly Stack<string> _expectedStartingColumn3 = new();

    public SupplyStacksTests()
    {
        _expectedStartingColumn1.Push("Z");
        _expectedStartingColumn1.Push("N");
        _expectedStartingColumn2.Push("M");
        _expectedStartingColumn2.Push("C");
        _expectedStartingColumn2.Push("D");
        _expectedStartingColumn3.Push("P");
    }

    [Fact]
    public void GetStartingInputCrates()
    {
        IDictionary<int, Stack<string>> starting = _sample.GetStartingCrates();

        starting.Should().HaveCount(3);

        starting[1].Should().BeEquivalentTo(_expectedStartingColumn1);
        starting[2].Should().BeEquivalentTo(_expectedStartingColumn2);
        starting[3].Should().BeEquivalentTo(_expectedStartingColumn3);
    }

    [Theory]
    [InlineData("    [D]    ", " D ")]
    [InlineData("[N] [C]    ", "NC ")]
    [InlineData("[Z] [M] [P]", "ZMP")]
    [InlineData("[D]                     [N] [F]    ", "D     NF ")]
    [InlineData("[H] [F]             [L] [J] [H]    ", "HF   LJH ")]
    [InlineData("[R] [H]             [F] [V] [G] [H]", "RH   FVGH")]
    [InlineData("[Z] [Q]         [Z] [W] [L] [J] [B]", "ZQ  ZWLJB")]
    [InlineData("[S] [W] [H]     [B] [H] [D] [C] [M]", "SWH BHDCM")]
    [InlineData("[P] [R] [S] [G] [J] [J] [W] [Z] [V]", "PRSGJJWZV")]
    [InlineData("[W] [B] [V] [F] [G] [T] [T] [T] [P]", "WBVFGTTTP")]
    [InlineData("[Q] [V] [C] [H] [P] [Q] [Z] [D] [W]", "QVCHPQZDW")]
    public void ParseLineShouldReturnExpected(string line, string expectedLine)
    {
        line.ParseLine().Should().Be(expectedLine);
    }

    [Fact]
    public void GetMovesShouldReturnMoves()
    {
        var moves = _sample.GetMoves();

        moves.Should().HaveCount(4);
    }

    [Theory]
    [InlineData("move 1 from 2 to 1", 1, 2, 1)]
    [InlineData("move 3 from 1 to 3", 3, 1, 3)]
    [InlineData("move 2 from 2 to 1", 2, 2, 1)]
    [InlineData("move 1 from 1 to 2", 1, 1, 2)]
    public void GetMoveShouldReturnMove(string move, int count, int from, int to)
    {
        var expectedMove = new Move(count, from, to);
        var actualMove = move.GetMove();

        actualMove.Should().Be(expectedMove);
    }

    [Fact]
    public void RearrangmentShouldProcessCorrectly()
    {
        var cargo = _sample.GetStartingCrates();
        
        var move = new Move(1,2,1);

        cargo = cargo.ProcessCrateMover9000Move(move);

        cargo[1].Peek().Should().Be("D");
        cargo[2].Peek().Should().Be("C");
        cargo[3].Peek().Should().Be("P");

        move = new Move(3,1,3);

        cargo = cargo.ProcessCrateMover9000Move(move);

        cargo[1].Should().BeEmpty();
        cargo[2].Peek().Should().Be("C");
        cargo[3].Peek().Should().Be("Z");

        move = new Move(2,2,1);

        cargo = cargo.ProcessCrateMover9000Move(move);

        cargo[1].Peek().Should().Be("M");
        cargo[2].Should().BeEmpty();
        cargo[3].Peek().Should().Be("Z");

        move = new Move(1,1,2);

        cargo = cargo.ProcessCrateMover9000Move(move);

        cargo[1].Peek().Should().Be("C");
        cargo[2].Peek().Should().Be("M");
        cargo[3].Peek().Should().Be("Z");
    }

    [Fact]
    public void RearrangmentShouldProcessMovesCorrectly()
    {
        var cargo = _sample.GetStartingCrates();
        
        var moves = _sample.GetMoves();

        cargo = cargo.ProcessMoves(moves);

        cargo[1].Peek().Should().Be("C");
        cargo[2].Peek().Should().Be("M");
        cargo[3].Peek().Should().Be("Z");
    }

    [Fact]
    public void DisplayTopCratesShouldReturn()
    {
        var cargo = _sample.GetStartingCrates();
        
        var moves = _sample.GetMoves();

        var display = cargo.ProcessMoves(moves).DisplayTopCrates();

        display.Should().Be("CMZ");
    }


    [Fact]
    public void RearrangmentCrafter9001ShouldProcessCorrectly()
    {
        var cargo = _sample.GetStartingCrates();
        
        var move = new Move(1,2,1);

        cargo = cargo.ProcessCrateMover9001Move(move);

        cargo[1].Peek().Should().Be("D");
        cargo[2].Peek().Should().Be("C");
        cargo[3].Peek().Should().Be("P");

        move = new Move(3,1,3);

        cargo = cargo.ProcessCrateMover9001Move(move);

        cargo[1].Should().BeEmpty();
        cargo[2].Peek().Should().Be("C");
        cargo[3].Peek().Should().Be("D");

        move = new Move(2,2,1);

        cargo = cargo.ProcessCrateMover9001Move(move);

        cargo[1].Peek().Should().Be("C");
        cargo[2].Should().BeEmpty();
        cargo[3].Peek().Should().Be("D");

        move = new Move(1,1,2);

        cargo = cargo.ProcessCrateMover9001Move(move);

        cargo[1].Peek().Should().Be("M");
        cargo[2].Peek().Should().Be("C");
        cargo[3].Peek().Should().Be("D");
    }
}