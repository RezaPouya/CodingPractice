namespace Bowling;

internal class BowlingGame
{
    public BowlingGame()
    {
        this.FrameIndex = 0;

        this.Frames = new List<BowlingGameTurn>()
        {
            new BowlingGameTurn()
        };

        this.CurrentFrame = 1;
    }

    public List<BowlingGameTurn> Frames { get; private set; }

    public int FrameIndex { get; protected set; }

    public int CurrentFrame { get; protected set; }

    public int RemainingRoll => this.Frames[this.FrameIndex].RemainingRoll;

    public BowlingGameTurn GetCurrentFrame()
    {
        return this.Frames[this.FrameIndex];
    }

    internal void Roll(int score = 0)
    {
        var turn = this.Frames[this.FrameIndex];

        if (turn.RemainingRoll == 0 && this.CurrentFrame == 10)
        {
            throw new Exception("You played your part and have no more turn");
        }

        turn.Roll(score);

        if (turn.IsStrike())
        {
            CreateNewFrame();
            return;
        }

        if (turn.RemainingRoll == 0 && this.CurrentFrame < 10)
        {
            CreateNewFrame();
        }
    }

    public int CalculateTotalScoreScore()
    {
        foreach (var item in this.Frames)
        {
            if (item is null)
                continue;

            item.ResetScore();
        }
            var score = 0;

        foreach (var item in this.Frames)
        {
            if (item is null)
                continue;

            if (item.IsSpare() == false && item.IsStrike() == false)
            {
                score += item.Score();
                continue;
            }

            if (item.IsSpare())
            {
                score = GetSpareScore(score, item);
            }

            if (item.IsStrike())
            {
                score = GetStrikeScore(score, item);
            }
        }

        return score;
    }

    private int GetSpareScore(int score, BowlingGameTurn item)
    {
        var nextTurnIndex = this.Frames.IndexOf(item) + 1;

        if (nextTurnIndex <= 9)
        {
            var nextTurn = this.Frames[nextTurnIndex];
            var nextTurnScore = nextTurn?.FirstRoll ?? 0;
            item.SetSpareScore(nextTurnScore);
        }

        score += item.SpareScore;

        return score;
    }

    private int GetStrikeScore(int score, BowlingGameTurn item)
    {
        var nextTurnIndex = this.Frames.IndexOf(item) + 1;
        var nextTurn = this.Frames[nextTurnIndex];

        if (nextTurn != null)
        {
            if (nextTurn.IsStrike())
            {
                var firstTurnScore = 10;
                var secondTurnFirstRollScore = 0;
                var next2ndTurn = this.Frames[nextTurnIndex + 1];
                if (next2ndTurn is not null)
                {
                    secondTurnFirstRollScore = nextTurn.FirstRoll ?? 0;
                }

                item.SetStrikeScore(firstTurnScore + secondTurnFirstRollScore);
            }
            else
            {
                item.SetStrikeScore(nextTurn.Score());
            }
        }

        score += item.StrikeScore;

        return score;
    }

    public BowlingGameTurn CreateNewFrame()
    {
        if (this.FrameIndex == 10)
        {
            this.FrameIndex--;
            throw new Exception("The game can only have 10 frames");
        }

        this.Frames.Add(new BowlingGameTurn());

        this.FrameIndex = this.FrameIndex + 1;

        this.CurrentFrame = this.CurrentFrame + 1;

        return this.Frames[this.FrameIndex];
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
            throw new Exception($"you didnt play {turn} turn ");
        }

        return frame.Score();
    }

    internal BowlingGameTurn GetTurn(int v)
    {
        return this.Frames[v - 1];
    }
}