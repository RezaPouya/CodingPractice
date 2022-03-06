namespace Bowling;

public class BowlingGameTurn
{
    public BowlingGameTurn()
    {
        this.FirstRoll = null;
        this.SecondRoll = null;
    }

    public int? FirstRoll { get; private set; }

    public int? SecondRoll { get; private set; }

    public bool IsStrike()
    {
        return (this.FirstRoll == 10);
    }

    public bool IsSpare()
    {
        bool isSpare = (IsStrike() == false && this.GetPureScore() == 10);
        return isSpare;
    }

    public int SpareScore { get; private set; }

    public int StrikeScore { get; private set; }

    public void SetSpareScore(int nextTurnScore)
    {
        if (this.IsStrike())
            throw new Exception("This is strike , so you can't set spare score");

        this.SpareScore = Score() + nextTurnScore;
    }

    public void SetStrikeScore(int nextTurnScore)
    {
        if (this.FirstRoll.Value != 10)
            throw new Exception("This is not Strike, so you can't set strike score");

        this.StrikeScore = Score() + nextTurnScore;
    }

    public void ResetScore()
    {
        this.StrikeScore = 0;
        this.SpareScore = 0;
    }

    public int RemainingRoll
    {
        get
        {
            if (FirstRoll is null && SecondRoll is null)
                return 2;

            if (FirstRoll is not null && SecondRoll is null)
                return 1;

            return 0;
        }
    }

    public void Roll(int score = 0)
    {
        if (score > 10)
            throw new Exception("Your score cannot be more than remaining pins in this frame");

        if (score < 0)
            throw new Exception("Your score cannot be less than 0");

        if (this.SecondRoll is not null)
            throw new Exception("You can't roll more");

        if (this.FirstRoll.GetValueOrDefault() + score > 10)
        {
            throw new Exception("Your score cannot be greater than remaining pins");
        }

        if (FirstRoll is null)
            this.FirstRoll = score;
        else
            this.SecondRoll = score;
    }

    public int Score()
    {
        if (IsSpare() == false && IsStrike() == false)
        {
            return this.FirstRoll.GetValueOrDefault() + this.SecondRoll.GetValueOrDefault();
        }

        if (IsSpare())
        {
            return this.SpareScore == 0 ? 10 : this.SpareScore;
        }

        return this.StrikeScore == 0 ? 10 : this.StrikeScore;
    }

    private int GetPureScore()
    {
        return this.FirstRoll.GetValueOrDefault() + this.SecondRoll.GetValueOrDefault();
    }
}