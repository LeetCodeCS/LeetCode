// https://leetcode.com/problems/132-pattern/
// Medium
/*
Given an array of n integers nums, a 132 pattern is a subsequence of three integers nums[i], nums[j] and nums[k] such that i < j < k and nums[i] < nums[k] < nums[j].

Return true if there is a 132 pattern in nums, otherwise return false.

 

Example 1:

Input: nums = [1,2,3,4]
Output: false
Explanation: There is no 132 pattern in the sequence.
Example 2:

Input: nums = [3,1,4,2]
Output: true
Explanation: There is a 132 pattern in the sequence: [1, 4, 2].
Example 3:

Input: nums = [-1,3,2,0]
Output: true
Explanation: There are three 132 patterns in the sequence: [-1, 3, 2], [-1, 3, 0] and [-1, 2, 0].
 

Constraints:

n == nums.length
1 <= n <= 3 * 104
-109 <= nums[i] <= 109
*/

// Brute Force O(n^3)
public class Solution {
    public bool Find132pattern(int[] nums) {
       for (int i = 0; i < nums.Length - 2; i++) {
            for (int j = i + 1; j < nums.Length - 1; j++) {
                for (int k = j + 1; k < nums.Length; k++) {
                    if (nums[k] > nums[i] && nums[j] > nums[k])
                        return true;
                }
            }
        }
        return false;
    }
}


// Brute Force better  O(n^2)
public class Solution {
    public bool Find132pattern(int[] nums) {
        int min_i = int.MaxValue;
        for (int j = 0; j < nums.Length - 1; j++) {
            min_i = Math.Min(min_i, nums[j]);
            for (int k = j + 1; k < nums.Length; k++) {
                if (nums[k] < nums[j] && min_i < nums[k])
                    return true;
            }
        }
        return false;
    }
}


// smart solution
// keep the value of s3 as big as possible
// use a "sorted" stack to maintain the candidates of s2 and s3.
public class Solution {
    public bool Find132pattern(int[] nums) {
		if (nums.Length < 3)
            return false;
       int centerValue = int.MinValue;	// will be nums[k] (between nums[i] and nums[j])
        var stack = new Stack<int>();
		// nums[i] < nums[k] < nums[j] && i < j < k
		// K will always be bigger than J and I (because we start from end), so we just need to check if nums[k] between
		// nums[i] and nums[j]
        for( int i = nums.Length - 1; i >= 0; i-- )
        {
            if( nums[i] < centerValue ) 
                return true;
            else 
                while(stack.Count != 0 && nums[i] > stack.Peek())
                    centerValue = stack.Pop(); 
            stack.Push(nums[i]);
        }
        return false;
    }
}

// Alterntive solution
public class Solution {
    public bool Find132pattern(int[] nums) {
        if (nums.Length < 3)
            return false;
        Stack<int> stack = new Stack<int>();
        int[] min = new int[nums.Length];
        
        min[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
            min[i] = Math.Min(min[i - 1], nums[i]);
        for (int j = nums.Length - 1; j >= 0; j--) {
            if (nums[j] > min[j]) {
                while (stack.Count>0 && stack.Peek() <= min[j])
                    stack.Pop();
                if (stack.Count>0 && stack.Peek() < nums[j])
                    return true;
                stack.Push(nums[j]);
            }
        }
        return false;
    }
}

