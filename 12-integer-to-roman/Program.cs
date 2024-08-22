using System.Diagnostics;
using System.Text;
using _12_integer_to_roman;

var solution = new Solution();

List<SolutionInput> solutionInputList = [
    new SolutionInput(3749, "MMMDCCXLIX"),
    new SolutionInput(58, "LVIII"),
    new SolutionInput(1994, "MCMXCIV")
];

Console.WriteLine("Gathering results");

var stopwatch = new Stopwatch();
var logBuilder = new StringBuilder().Append('\n');

foreach (var input in solutionInputList)
{
    stopwatch.Start();
    var result = solution.IntToRoman(input.Input);
    stopwatch.Stop();

    Console.WriteLine(
        "(result={0}; output={1}; expectedOutput={2}; time={3}; input={4};",
        result == input.Target,
        result,
        input.Target,
        stopwatch.Elapsed,
        string.Join(", ", input.Input)
    );
}

Console.WriteLine(logBuilder.ToString());

Console.WriteLine("Done...");

public record SolutionInput(int Input, string Target);