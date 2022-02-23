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

        if (turn.RemainingRoll == 0 && this.CurrentFrame < 10)
        {
            CreateNewFrame();
        }
    }

    public int Score()
    {
        var score = 0;
        foreach (var item in this.Frames)
        {
            if (item is null)
                continue;

            if (item.IsSpare() == false)
            {
                score += item.Score();
                continue;
            }

            var nextTurnIndex = this.Frames.IndexOf(item) + 1;

            if (nextTurnIndex <= 9)
            {
                var nextTurnScore = this.Frames[nextTurnIndex].Score();
                item.SetSpareScore(nextTurnScore);
            }

            score += item.SpareScore;
        }

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
}