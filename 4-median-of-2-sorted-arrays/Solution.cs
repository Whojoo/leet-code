public class Solution
{
    public double FindMedianSortedArrays(int[] numbersArray1, int[] numbersArray2)
    {
        var totalLength = numbersArray1.Length + numbersArray2.Length;

        double[] totalArray = [.. numbersArray1, .. numbersArray2];

        var span = totalArray.AsSpan();
        span.Sort();

        var isEven = totalLength % 2 == 0;
        var medianIndex = (totalLength - 1) / 2;

        return isEven
            ? (span[medianIndex] + span[medianIndex + 1]) / 2
            : span[medianIndex];
    }
}
