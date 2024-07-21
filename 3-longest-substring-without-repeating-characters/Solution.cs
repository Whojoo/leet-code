public class Solution
{
    public int LengthOfLongestSubstring(string inputString)
    {
        var characterSet = new HashSet<char>(inputString.Length);
        var maxLength = 0;

        for (var i = 0; i < inputString.Length; i++)
        {
            var currentChar = inputString[i];
            characterSet.Clear();
            characterSet.Add(currentChar);
            var currentLength = 1;

            for (var j = i + 1; j < inputString.Length; j++)
            {
                var nextChar = inputString[j];
                var isAdded = characterSet.Add(nextChar);

                if (isAdded)
                {
                    currentLength++;
                }
                else
                {
                    break;
                }
            }

            maxLength = Math.Max(currentLength, maxLength);

            if (inputString.Length - (i + 1) <= maxLength)
            {
                break;
            }
        }

        return maxLength;
    }
}