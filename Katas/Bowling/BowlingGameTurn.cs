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

    public bool IsSpare()
    {
        if (this.Score() == 10)
            return true;

        return false;
    }

    public bool IsStrike { get; private set; }

    public int SpareScore { get; private set; }

    public void SetSpareScore(int nextTurnScore)
    {
        this.SpareScore = Score() + nextTurnScore;
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
        return this.FirstRoll.GetValueOrDefault() + this.SecondRoll.GetValueOrDefault();
    }
}