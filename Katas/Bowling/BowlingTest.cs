namespace Bowling;

public class BowlingTest
{
    private BowlingGame _bowlingGame = new BowlingGame();

    [Fact]
    public void WeShouldHaveGame_Initial_Game()
    {
        Assert.NotNull(_bowlingGame);
        Assert.Equal(0, _bowlingGame.Score);
    }

    [Fact]
    public void We_Should_Have_2_Roll_First_We_Role_Once_Then_We_Have_1_Remaining_Roll()
    {
        _bowlingGame.Roll();
        Assert.Equal(1, _bowlingGame.RemainingRoll);
    }

    [Fact]
    public void We_Should_Have_2_Roll_Then_Go_To_Turn_2()
    {
        _bowlingGame.Roll();
        _bowlingGame.Roll();
        Assert.Equal(2, _bowlingGame.Turn);
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
        Assert.Equal(1, _bowlingGame.Turn);

        _bowlingGame.Roll();
        _bowlingGame.Roll();

        Assert.Equal(2, _bowlingGame.Turn);

        _bowlingGame.Roll();
        _bowlingGame.Roll();

        Assert.Equal(3, _bowlingGame.Turn);
    }

    [Fact]
    public void We_Should_Have_20_Roll_Then_Have_0_Remaining_Frame()
    {
        Roll_For(20);
        Assert.Equal(10, _bowlingGame.Turn);
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

        Assert.Equal("You can't roll more", exception.Message);

        Assert.Equal(10, _bowlingGame.Turn);
    }

    [Fact]
    public void We_Should_Have_1_Roll_Which_Topple_5_Pins_And_Have_Score_5()
    {
        // act
        _bowlingGame.Roll(5);
        Assert.Equal(5, _bowlingGame.Score);
    }

    [Fact]
    public void We_Should_Have_1_Roll_Which_Topple_6_Pins_And_Have_Score_6()
    {
        // act
        _bowlingGame.Roll(6);
        Assert.Equal(6, _bowlingGame.Score);
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
        Assert.Equal(3, _bowlingGame.Score);
        _bowlingGame.Roll(4);
        Assert.Equal(7, _bowlingGame.Score);
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
        _bowlingGame.Roll(9);
        _bowlingGame.Roll(1);
        _bowlingGame.Roll(5);
        _bowlingGame.Roll(3);
        Assert.Equal(18, _bowlingGame.Score);
    }

    /// <summary>
    ///    - If in two tries he knocks them all down, this is called a “spare” and
    /// his score for the frame is ten plus the number of pins knocked down on his next throw (in his next turn).
    /// </summary>
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
    ///    - If in two tries he knocks them all down, this is called a “spare” and
    /// his score for the frame is ten plus the number of pins knocked down on his next throw (in his next turn).
    /// </summary>
    [Fact]
    public void We_Spare_In_First_Frame_Then_Roll_And_Score_8_Pins_In_Frame_2_Then_Total_Score_Should_Be_26()
    {
        _bowlingGame.Roll(9);
        _bowlingGame.Roll(1);
        _bowlingGame.Roll(5);
        _bowlingGame.Roll(3);
        Assert.Equal(26, _bowlingGame.Score);
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