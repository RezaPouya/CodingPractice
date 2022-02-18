using System;
using System.Linq;

namespace EvenOrOdd;

public class EvenOrOddInterpreter
{
    public EvenOrOddInterpreter()
    {
    }

    public const string Even = "even";
    public const string Odd = "odd";

    public  string IsAddOrEven(string initialData)
    {
        if(string.IsNullOrEmpty(initialData))
            return Even;

        var sanitizedData = initialData.Replace("[", "").Replace("]", "").Trim().Split(",");

        var sum = sanitizedData.Select(p=> int.Parse(p.Trim())).Sum();

        if (sum % 2 == 0)
            return Even;

        return Odd;
    }

    public string IsAddOrEven(params int[] input)
    {
        if (input.Count() == 0)
            return Even;

        if (input.Sum() % 2 == 0)
            return Even;

        return Odd;
    }
}