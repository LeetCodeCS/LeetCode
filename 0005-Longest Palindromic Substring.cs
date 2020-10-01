// https://leetcode.com/problems/longest-palindromic-substring/
// Medium
/*
Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

Example 1:

Input: "babad"
Output: "bab"
Note: "aba" is also a valid answer.
Example 2:

Input: "cbbd"
Output: "bb"
*/

public class Solution {
    public string LongestPalindrome(string s) {
        if (s == null || s.Length < 1) {
            return string.Empty;
        }
        int max = 0;
        int l = 0;
        for (int i = 0; i < s.Length; i++) {
            // for odd
            var A = ExpandAndValidate(s, i, i);
            // for even
            var B = ExpandAndValidate(s, i, i+1);
            if (A.Item1 > B.Item1) {
                if (A.Item1 > max) {
                    l = A.Item2;
                    max = A.Item1;
                }
            } else {
                if (B.Item1 > max) {
                    l = B.Item2;
                    max = B.Item1;
                }
            }
        }
        return s.Substring(l, max);
    }
    
    // Item1 = length, Item2 = start
    private Tuple<int, int> ExpandAndValidate(string s, int left, int right) {
        int L = left;
        int R = right;
        while (L >= 0 && R < s.Length && s[R] == s[L]) {
            L--;
            R++;
        }
        return new Tuple<int, int>(R-L-1, L+1);
    }
}
