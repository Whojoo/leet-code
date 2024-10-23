using System.Text;

namespace _12_integer_to_roman;

public class Solution
{
    private readonly struct CalculationSet(
        int highNumber,
        int midNumber,
        int lowNumber,
        char highCharacter,
        char midCharacter,
        char lowCharacter)
    {
        public int HighNumber { get; } = highNumber;
        public int MidNumber { get; } = midNumber;
        public int LowNumber { get; } = lowNumber;
        public char HighCharacter { get; } = highCharacter;
        public char MidCharacter { get; } = midCharacter;
        public char LowCharacter { get; } = lowCharacter;
    }

    public string IntToRoman(int num)
    {
        CalculationSet[] calculationSets =
        [
            new CalculationSet(10000, 5000, 1000, '@', '@', 'M'),
            new CalculationSet(1000, 500, 100, 'M', 'D', 'C'),
            new CalculationSet(100, 50, 10, 'C', 'L', 'X'),
            new CalculationSet(10, 5, 1, 'X', 'V', 'I')
        ];

        var output = string.Empty;
        var input = num;

        foreach (var calculationSet in calculationSets)
        {
            // Rule 0. Should we skip this calculation set?
            if (input < calculationSet.LowNumber)
            {
                continue;
            }

            // Rule 1. Is the input less than 4 times LowNumber? => 1-3 LowCharacter
            if (input < calculationSet.LowNumber * 4)
            {
                do
                {
                    output += calculationSet.LowCharacter;
                    input -= calculationSet.LowNumber;
                } while (input >= calculationSet.LowNumber);
                continue;
            }

            // Rule 2. Is the input less than MidNumber? => LowCharacter + MidCharacter
            if (input < calculationSet.MidNumber)
            {
                output += calculationSet.LowCharacter;
                output += calculationSet.MidCharacter;
                input -= calculationSet.LowNumber * 4;
                continue;
            }

            // Rule 3. Is the input less than MidNumber + LowNumber? => MidCharacter
            if (input < calculationSet.MidNumber + calculationSet.LowNumber)
            {
                output += calculationSet.MidCharacter;
                input -= calculationSet.MidNumber;
                continue;
            }

            // Rule 4. Is the input less than HighNumber - LowNumber? => MidCharacter + 1-3 LowCharacter
            if (input < calculationSet.HighNumber - calculationSet.LowNumber)
            {
                output += calculationSet.MidCharacter;
                input -= calculationSet.MidNumber;
                do
                {
                    output += calculationSet.LowCharacter;
                    input -= calculationSet.LowNumber;
                } while (input >= calculationSet.LowNumber);
                continue;
            }

            // Rule 5. => LowCharacter + HighCharacter
            output += calculationSet.LowCharacter;
            output += calculationSet.HighCharacter;
            input -= calculationSet.HighNumber - calculationSet.LowNumber;
        }

        return output;
    }
}