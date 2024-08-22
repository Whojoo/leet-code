using System.Diagnostics;
using System.Text;

var solution = new Solution();

List<SolutionInput> solutionInputList = [
    new SolutionInput([1, 3], [2], 2),
    new SolutionInput([1, 2], [3, 4], 2.5),
    new SolutionInput([1], [3], 2),
    new SolutionInput([1], [3, 4], 3),
    new SolutionInput([], [3, 4], 3.5),
    new SolutionInput([4, 5], [3, 8, 9, 20, 38, 40, 55], 9),
];

Console.WriteLine("Gathering results");

var stopwatch = new Stopwatch();
var logBuilder = new StringBuilder().Append('\n');

foreach (var input in solutionInputList)
{
    stopwatch.Start();
    var result = solution.FindMedianSortedArrays(input.FirstArrayInput, input.SecondArrayInput);
    stopwatch.Stop();

    Console.WriteLine(
            "(result={0}; output={1}; expectedOutput={2}; time={3}; firstArray=[{4}]; secondArray=[{5}];",
            result == input.Target,
            result,
            input.Target,
            stopwatch.Elapsed,
            string.Join(", ", input.FirstArrayInput),
            string.Join(", ", input.SecondArrayInput)
        );
}

Console.WriteLine(logBuilder.ToString());

Console.WriteLine("Done...");

public class SolutionInput(int[] firstArrayInput, int[] secondArrayInput, double target)
{
    public int[] FirstArrayInput { get; set; } = firstArrayInput;
    public int[] SecondArrayInput { get; set; } = secondArrayInput;
    public double Target { get; private set; } = target;
}