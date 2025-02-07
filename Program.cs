var solution = new Solution();
var shouldOutputTwo = "()(()";
solution.LongestValidParentheses(shouldOutputTwo);
public class Solution
{
    /// <summary>
    /// Finds the length of the longest valid (well-formed) parentheses substring.
    /// </summary>
    /// <param name="s">The input string containing only '(' and ')'</param>
    /// <returns>The length of the longest valid parentheses substring</returns>
    public int LongestValidParentheses(string s)
    {
        // If the string length is less than 2, it cannot contain any valid parentheses
        if (s.Length < 2) return 0;

        int longestValidLength = 0; // Variable to store the maximum length of valid parentheses
        Stack<int> indexStack = new Stack<int>(); // Stack to store indices of '(' characters
        indexStack.Push(-1); // Initialize stack with a base index to handle edge cases

        // Iterate through each character in the string
        for (int currentIndex = 0; currentIndex < s.Length; currentIndex++)
        {
            if (s[currentIndex] == '(')
            {
                // Push the index of '(' onto the stack
                indexStack.Push(currentIndex);
            }
            else
            {
                // Pop the top index from the stack
                indexStack.Pop();
                if (indexStack.Count == 0)
                {
                    // If the stack is empty, push the current index as a new base index
                    indexStack.Push(currentIndex);
                }
                else
                {
                    // Calculate the length of the current valid substring
                    int validSubstringLength = currentIndex - indexStack.Peek();
                    // Update the maximum length if the current valid substring is longer
                    longestValidLength = Math.Max(longestValidLength, validSubstringLength);
                }
            }
            // Example for input: "()(()"
            // Stack: [-1] -> Push '(' at index 0 -> Stack: [-1, 0]
            // Stack: [-1, 0] -> Pop ')' at index 1 -> Stack: [-1] -> Valid length: 1 - (-1) = 2
            // Stack: [-1] -> Push '(' at index 2 -> Stack: [-1, 2]
            // Stack: [-1, 2] -> Push '(' at index 3 -> Stack: [-1, 2, 3]
            // Stack: [-1, 2, 3] -> Pop ')' at index 4 -> Stack: [-1, 2] -> Valid length: 4 - 2 = 2
        }

        return longestValidLength; 
    }
}
