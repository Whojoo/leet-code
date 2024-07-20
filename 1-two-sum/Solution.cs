public class Solution
{

    public int[] TwoSum(int[] inputNumbers, int target)
    {
        var set = new HashSet<int>(inputNumbers.Length);
        var doublesSet = new HashSet<int>();

        for (var i = 0; i < inputNumbers.Length; i++)
        {
            var input = inputNumbers[i];
            var wasAdded = set.Add(input);
            if (!wasAdded)
            {
                doublesSet.Add(input);
            }
        }

        var length = inputNumbers.Length + 1 / 2;

        for (var i = 0; i < length; i++)
        {
            var input = inputNumbers[i];
            var missing = target - input;

            if (set.Contains(missing))
            {
                if (missing == input && !doublesSet.Contains(input))
                {
                    continue;
                }

                return GetIndices(input, missing, inputNumbers);
            }
        }

        return [-1, -1];
    }

    public static int[] GetIndices(int left, int right, int[] inputNumbers)
    {
        var inputList = inputNumbers.ToList();

        var actualLeftIndex = inputList.IndexOf(left);
        var actualRightIndex = inputList.IndexOf(right, actualLeftIndex + 1);

        return [actualLeftIndex, actualRightIndex];
    }
}