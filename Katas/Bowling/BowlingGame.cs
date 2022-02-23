namespace Bowling;

internal class BowlingGame
{
    public BowlingGame()
    {
        this.Score = 0;
        this.TurnIndex = 0;

        this.Frames = new List<BowlingGameTurn>()
        {
            new BowlingGameTurn()
        };

        this.Turn = 1;
    }

    public List<BowlingGameTurn> Frames { get; private set; }

    public int TurnIndex { get; protected set; }

    public int Turn { get; protected set; }

    public int Score { get; internal set; }
    public int RemainingRoll => this.Frames[this.TurnIndex].RemainingRoll;

    internal void Roll(int score = 0)
    {
        var turn = this.Frames[this.TurnIndex];

        if (turn.RemainingRoll == 0 && this.Turn == 10)
        {
            throw new Exception("You played your part and have no more turn");
        }

        turn.Roll(score);

        if (turn.RemainingRoll == 0 && this.Turn < 10)
        {
            this.Score += turn.Score();
            CreateNewTurnAndReturnIt();
        }
    }

    public BowlingGameTurn CreateNewTurnAndReturnIt()
    {
        if (this.TurnIndex == 10)
        {
            this.TurnIndex--;
            throw new Exception("The game can only have 10 frames");
        }

        this.Frames.Add(new BowlingGameTurn());

        this.TurnIndex = this.TurnIndex + 1;

        this.Turn = this.Turn + 1;

        return this.Frames[this.TurnIndex];
    }

    internal int GetTurnScore(int turn)
    {
        if (turn > 10 || turn < 0)
        {
            throw new Exception($"you didnt play {turn} turn ");
        }

        var frame = this.Frames[turn - 1];

        if (frame is null)
        {
            throw new Exception($"you didnt play {} turn ");
        }

        return frame.Score();
    }
}