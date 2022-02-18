using Xunit;

namespace EvenOrOdd;

public class EvenOrOddTest

{
    [Theory]
    [InlineData("", "even")]
    [InlineData("[0]", "even")]
    [InlineData("[2, 5, 34, 6]", "odd")]
    [InlineData("[0, -1, -5]", "even")]
    public void ShouldPassIfInputIsString(string initialData, string acceptedResult)
    {
        EvenOrOddInterpreter interpreter = new EvenOrOddInterpreter();

        var result = interpreter.IsAddOrEven(initialData);

        Assert.Equal(acceptedResult, result);
    }

    [Theory]
    [InlineData(new int[0], "even")]
    [InlineData(new int[] { 0 }, "even")]
    [InlineData(new int[] { 2  , 5 , 34 , 6 }, "odd")]
    [InlineData(new int[] { 0  , -1 , -5 }, "even")]
    public void ShouldPassIfInputIsArray(int[] initialData, string acceptedResult)
    {
        EvenOrOddInterpreter interpreter = new EvenOrOddInterpreter();

        var result = interpreter.IsAddOrEven(initialData);

        Assert.Equal(acceptedResult, result);
    }
}