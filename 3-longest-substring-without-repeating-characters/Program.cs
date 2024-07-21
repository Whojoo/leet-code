using System.Diagnostics;
using System.Text;

var solution = new Solution();

List<SolutionInput> solutionInputList = [
    new SolutionInput("abcabcbb", 3),
    new SolutionInput("bbbbb", 1),
    new SolutionInput("pwwkew", 3),
    new SolutionInput("", 0),
    new SolutionInput(" ", 1),
    new SolutionInput("au", 2),
];

Console.WriteLine("Gathering results");

var stopwatch = new Stopwatch();
var logBuilder = new StringBuilder().Append('\n');

foreach (var input in solutionInputList)
{
    stopwatch.Start();
    var result = solution.LengthOfLongestSubstring(input.Input);
    stopwatch.Stop();

    logBuilder
        .Append(string.Format(
            "(result={0}; output=[{1}]; expectedOutput=[{2}]; time={3}; input=[{4}];",
            result == input.Target,
            result,
            input.Target,
            stopwatch.Elapsed,
            input.Input
        ))
        .Append('\n');
}

Console.WriteLine(logBuilder.ToString());

Console.WriteLine("Done...");

public class SolutionInput(string input, int target)
{
    public string Input { get; private set; } = input;
    public int Target { get; private set; } = target;
}