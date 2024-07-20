
using System.Diagnostics;
using System.Text;

var solution = new Solution();

List<SolutionInput> solutionInputList = [
    new SolutionInput([2, 4, 3], [5, 6, 4], [7, 0, 8]),
    new SolutionInput([0], [0], [0]),
    new SolutionInput([9, 9, 9, 9, 9, 9, 9], [9, 9, 9, 9], [8, 9, 9, 9, 0, 0, 0, 1]),
];

Console.WriteLine("Gathering results");

var stopwatch = new Stopwatch();
var logBuilder = new StringBuilder().Append('\n');

foreach (var input in solutionInputList)
{
    stopwatch.Start();
    var result = solution.AddTwoNumbers(input.LeftInput, input.RightInput);
    stopwatch.Stop();

    logBuilder
        .Append(string.Format(
            "(result={0}; output=[{1}]; expectedOutput=[{2}]; time={3}; leftInput=[{4}]; rightInput=[{5}])",
            IsResultValid(result, input.Target),
            string.Join(", ", ToList(result)),
            string.Join(", ", ToList(input.Target)),
            stopwatch.Elapsed,
            string.Join(", ", ToList(input.LeftInput)),
            string.Join(", ", ToList(input.RightInput))
        ))
        .Append('\n');
}

Console.WriteLine(logBuilder.ToString());

Console.WriteLine("Done...");

bool IsResultValid(ListNode result, ListNode target)
{
    var resultList = ToList(result);
    var targetList = ToList(target);

    return resultList.SequenceEqual(targetList);
}

List<int> ToList(ListNode target)
{
    var list = new List<int>();
    var current = target;
    do
    {
        list.Add(current.val);
        current = current.next;
    }
    while (current is not null);
    return list;
}

public class SolutionInput(int[] left, int[] right, int[] target)
{
    public int[] Left { get; } = left;
    public int[] Right { get; } = right;
    public ListNode Target { get; } = CreateInput(target);
    public ListNode LeftInput { get; } = CreateInput(left);
    public ListNode RightInput { get; } = CreateInput(right);

    private static ListNode CreateInput(int[] inputNumber)
    {
        ListNode previous = null;

        for (var i = inputNumber.Length - 1; i >= 0; i--)
        {
            var newNode = new ListNode(inputNumber[i], previous);
            previous = newNode;
        }

        return previous;
    }
}