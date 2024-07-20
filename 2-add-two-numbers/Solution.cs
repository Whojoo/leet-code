/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode AddTwoNumbers(ListNode left, ListNode right)
    {
        var (currentVal, saved) = CalculateCurrentValAndSaved(left, right);
        var solution = new ListNode(currentVal);

        var solutionCalculationObject = solution;
        ListNode? currentLeft = left.next;
        ListNode? currentRight = right.next;

        while (currentLeft is not null || currentRight is not null)
        {
            (currentVal, saved) = CalculateCurrentValAndSaved(currentLeft, currentRight, saved);
            solutionCalculationObject.next = new ListNode(currentVal);

            solutionCalculationObject = solutionCalculationObject.next;
            currentLeft = GetNext(currentLeft);
            currentRight = GetNext(currentRight);
        }

        if (saved > 0)
        {
            solutionCalculationObject.next = new ListNode(saved);
        }

        return solution;
    }

    private static int GetVal(ListNode? node)
        => node?.val ?? 0;

    private static ListNode? GetNext(ListNode? current)
        => current?.next;

    private static (int currentVal, int saved) CalculateCurrentValAndSaved(ListNode? left, ListNode? right, int previousSaved = 0)
    {
        var currentVal = GetVal(left) + GetVal(right) + previousSaved;
        var saved = currentVal / 10;

        return (currentVal - (saved * 10), saved);
    }
}