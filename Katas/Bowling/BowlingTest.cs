namespace Bowling;

public class BowlingTest
{
    private BowlingGame _bowlingGame = new BowlingGame();

    [Fact]
    public void WeShouldGame()
    {
        Assert.NotNull(_bowlingGame);
        Assert.Equal(0, _bowlingGame.CalculateTotalScoreScore());
    }

    [Fact]
    public void TheReamaingRoll_ShouldBe_1_WhenWeRollOnce()
    {
        _bowlingGame.Roll();
        Assert.Equal(1, _bowlingGame.RemainingRoll);
    }

    [Fact]
    public void TheRemainingTurnShouldBe_2_WhenWeRollFor2Times()
    {
        _bowlingGame.Roll();
        _bowlingGame.Roll();
        Assert.Equal(2, _bowlingGame.CurrentFrame);
    }

    [Fact]
    public void We_Should_Have_2_Roll_Then_Have_9_Remaining_Frame_And_Reset_Roll()
    {
        _bowlingGame.Roll();
        _bowlingGame.Roll();
        Assert.Equal(2, _bowlingGame.RemainingRoll);
    }

    [Fact]
    public void We_Should_Have_2_Roll_Then_Have_9_Remaining_Frame_And_Reset_Roll_Then_If_We_Roll_For_Another_Time_Remaining_Roll_Should_Be_1()
    {
        _bowlingGame.Roll();
        _bowlingGame.Roll();
        _bowlingGame.Roll();
        Assert.Equal(1, _bowlingGame.RemainingRoll);
    }

    [Fact]
    public void We_Should_Have_4_Roll_Then_And_Be_In_Second_Turn()
    {
        Assert.Equal(1, _bowlingGame.CurrentFrame);

        _bowlingGame.Roll();
        _bowlingGame.Roll();

        Assert.Equal(2, _bowlingGame.CurrentFrame);

        _bowlingGame.Roll();
        _bowlingGame.Roll();

        Assert.Equal(3, _bowlingGame.CurrentFrame);
    }

    [Fact]
    public void We_Should_Have_20_Roll_Then_Have_0_Remaining_Frame()
    {
        Roll_For(20);
        Assert.Equal(10, _bowlingGame.CurrentFrame);
    }

    [Fact]
    public void We_Should_Have_20_Roll_Then_Have_0_Remaining_Frame_And_0_Remaining_Roll()
    {
        Roll_For(20);

        Action act = () => _bowlingGame.Roll(21);

        Exception exception = Assert.Throws<Exception>(act);

        Assert.Equal("You played your part and have no more turn", exception.Message);
    }

    [Fact]
    public void We_Try_Roll_While_We_Dont_Have_Roll_Then_Should_Have_Exception_That_You_Dont_Have_Anymore_Roll()
    {
        Roll_For(20);

        Action act = () => _bowlingGame.Roll();

        Exception exception = Assert.Throws<Exception>(act);

        Assert.Equal("You played your part and have no more turn", exception.Message);
    }

    [Fact]
    public void We_Should_Have_1_Roll_Which_Topple_5_Pins_And_Have_Score_5()
    {
        // act
        _bowlingGame.Roll(5);
        _bowlingGame.Roll(5);
        Assert.Equal(10, _bowlingGame.CalculateTotalScoreScore());
    }

    [Fact]
    public void We_Should_Have_1_Roll_Which_Topple_6_Pins_And_Have_Score_6()
    {
        // act
        _bowlingGame.Roll(6);
        Assert.Equal(6, _bowlingGame.GetCurrentFrame().Score());
    }

    [Fact]
    public void If_We_Roll_Which_Topple_More_Than_10_Pins_Then_We_Should_Have_Exception()
    {
        // act
        Action act = () => _bowlingGame.Roll(11);

        Exception exception = Assert.Throws<Exception>(act);

        Assert.Equal("Your score cannot be more than remaining pins in this frame", exception.Message);
    }

    [Fact]
    public void If_We_Roll_Which_Topple_Less_Than_0_Pins_Then_We_Should_Have_Exception()
    {
        // act
        Action act = () => _bowlingGame.Roll(-1);

        Exception exception = Assert.Throws<Exception>(act);

        Assert.Equal("Your score cannot be less than 0", exception.Message);
    }

    [Fact]
    public void We_Roll_1st_Time_With_Score__of_3_Then_Roll_For_2nd_Time_With_Score_of_4_The_We_Should_Have_Score_of_7()
    {
        _bowlingGame.Roll(3);
        Assert.Equal(3, _bowlingGame.GetCurrentFrame().Score());
        _bowlingGame.Roll(4);
        Assert.Equal(7, _bowlingGame.CalculateTotalScoreScore());
    }

    [Fact]
    public void We_Roll_1st_Time_With_Score_of_6_Then_Roll_For_2nd_Time_With_Score_of_7_Then_We_Should_Have_Exception()
    {
        _bowlingGame.Roll(6);

        Action act = () => _bowlingGame.Roll(7);

        Exception exception = Assert.Throws<Exception>(act);

        Assert.Equal("Your score cannot be greater than remaining pins", exception.Message);
    }

    [Fact]
    public void We_Roll_4_Times_With_Score_Of_9_1_5_3_Then_Total_Score_Should_Be_18()
    {
        _bowlingGame.Roll(7);
        _bowlingGame.Roll(1);
        _bowlingGame.Roll(5);
        _bowlingGame.Roll(3);
        Assert.Equal(16, _bowlingGame.CalculateTotalScoreScore());
    }

    [Fact]
    public void We_Play_2_Time_And_Should_Have_Know_Our_Frame_Score_In_Each_Frame()
    {
        _bowlingGame.Roll(9);
        _bowlingGame.Roll(1);
        _bowlingGame.Roll(5);
        _bowlingGame.Roll(3);
        Assert.Equal(10, _bowlingGame.GetTurnScore(1));
        Assert.Equal(8, _bowlingGame.GetTurnScore(2));
    }

    /// <summary>
    ///    - If in two tries he knocks them all down, this is called a ?spare? and
    /// his score for the frame is ten plus the number of pins knocked down on his next throw (in his next turn).
    /// </summary>
    [Fact]
    public void WeShouldSpareInFirstFrameThenOurScoreShouldBe_23_AtStartOfFrame_3()
    {
        _bowlingGame.Roll(9);
        _bowlingGame.Roll(1);
        _bowlingGame.Roll(5);
        _bowlingGame.Roll(3);
        Assert.Equal(3, _bowlingGame.CurrentFrame);
        Assert.Equal(23, _bowlingGame.CalculateTotalScoreScore());
    }

    /// <summary>
    ///  - If on his first try in the frame he knocks down all the pins, this is called a ?strike?. His turn is over,
    /// and his score for the frame is ten plus the simple total of the pins knocked down in his next two rolls.
    /// </summary>
    [Fact]
    public void AfterStrikeInFirstRollTheTurnShouldIncrease()
    {
        _bowlingGame.Roll(10);
        Assert.Equal(2, _bowlingGame.CurrentFrame);
        _bowlingGame.Roll(3);
        Assert.Equal(2, _bowlingGame.CurrentFrame);
    }

    [Fact]
    public void AfterStrikeItShouldntConsiderFrameAsSpare()
    {
        _bowlingGame.Roll(10);
        var turn = _bowlingGame.GetTurn(1);
        Assert.False(turn.IsSpare());
    }


    /// <summary>
    ///  - If on his first try in the frame he knocks down all the pins, this is called a ?strike?. His turn is over,
    /// and his score for the frame is ten plus the simple total of the pins knocked down in his next two rolls.
    /// </summary>
    [Fact]
    public void AfterStrikeItShouldAddTotal()
    {
        _bowlingGame.Roll(10);
        _bowlingGame.Roll(1);
        _bowlingGame.Roll(5);
        _bowlingGame.CalculateTotalScoreScore();
        var frstTurn = _bowlingGame.GetTurn(1);
        var score = frstTurn.Score();
        Assert.Equal(16, score);
        Assert.Equal(16 + 6, _bowlingGame.CalculateTotalScoreScore());
    }


    private void Roll_For(int itteration = 1)
    {
        while (itteration > 0)
        {
            itteration--;
            _bowlingGame.Roll(3);
        }
    }
}