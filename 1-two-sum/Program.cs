
using System.Diagnostics;
using System.Text;

var solution = new Solution();

List<SolutionInput> failingInputList = [
    new SolutionInput([2, 7, 11, 15], 9),
    new SolutionInput([3, 2, 4], 6),
    new SolutionInput([3, 3], 6),
    new SolutionInput([3, 2, 3], 6),
    new SolutionInput([0, 4, 3, 0], 0),
    new SolutionInput([-1, -2, -3, -4, -5], -8)
];

Console.WriteLine("Gathering results");

var stopwatch = new Stopwatch();
var logBuilder = new StringBuilder().Append('\n');

foreach (var input in failingInputList)
{
    stopwatch.Start();
    var result = solution.TwoSum(input.Input, input.Target);
    stopwatch.Stop();

    logBuilder.Append($"Found solution [{string.Join(',', result)}] in {stopwatch.Elapsed} for input {input}");
    logBuilder.Append('\n');
}

Console.WriteLine(logBuilder.ToString());

Console.WriteLine("Done...");

public struct SolutionInput(int[] input, int target)
{
    public readonly int[] Input { get; } = input;
    public readonly int Target { get; } = target;

    public override string ToString()
    {
        return string.Format(
            "(target={0}; input=[{1}])",
            Target,
            string.Join(',', Input)
        );
    }
}