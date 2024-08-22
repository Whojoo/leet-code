using System.Text;

namespace _12_integer_to_roman;

public class Solution
{
    public string IntToRoman(int num)
    {
        char[] characters = ['M', 'D', 'C', 'L', 'X', 'V', 'I'];
        int[] values = [1000, 500, 100, 50, 10, 5, 1];

        var stringBuilder = new StringBuilder();

        for (var i = 0; i < characters.Length; i++)
        {
            var input = string.Empty;
            var maxRotations = i % 2 == 1 ? 2 : 4;
            var rotations = 0;

            while (num >= values[i] && rotations < maxRotations)
            {
                num -= values[i];
                input += characters[i];
                rotations++;
            }

            if (input.Length == maxRotations)
            {
                input = maxRotations == 2
                    ? string.Empty
                    :$"{characters[i]}{characters[i - 1]}";
            }

            if (input.Length > 0)
            {
                stringBuilder.Append(input);
            }
        }

        return stringBuilder.ToString();
    }
}