// https://leetcode.com/problems/two-sum/
// Easy
/*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

 

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Output: Because nums[0] + nums[1] == 9, we return [0, 1].
Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]
 

Constraints:

2 <= nums.length <= 105
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists.
*/

// Brute force
/*
Time complexity : O(n^2)O(n2). 
For each element, we try to find its complement by looping through the rest of array which takes O(n)O(n) time. 
Therefore, the time complexity is O(n^2)O(n2).
Space complexity : O(1)O(1).
*/
public int[] TwoSum(int[] nums, int target) {
	for(int i=0;i<nums.Length;i++)
	{
		for(int j=i+1;j<nums.Length;j++)
		{
			if(nums[i]+nums[j]==target)
				return new int[]{i,j};
		}
	}
	return new int[0];
	
}

// Two pass hash
/*
Time complexity : O(n)O(n). We traverse the list containing nn elements exactly twice. 
Since the hash table reduces the look up time to O(1)O(1), the time complexity is O(n)O(n).

Space complexity : O(n)O(n). The extra space required depends on the number of items stored in the hash table, 
which stores exactly nn elements.
*/

public int[] TwoSum(int[] nums, int target) {
	int[] result=new int[2];
	Dictionary<int,int> hashmap=new Dictionary<int,int>();
	for(int i=0;i<nums.Length;i++)
	{
		hashmap[nums[i]]=i;
	}
	for(int i=0;i<nums.Length;i++)
	{
		int restOfSum=target-nums[i];
		if(hashmap.ContainsKey(restOfSum) && hashmap[restOfSum]!=i)
		{
			result[0]=hashmap[restOfSum];
			result[1]=i;
			break;
		}
	}
	return result;
	
}

// One hash pass
public int[] TwoSum(int[] nums, int target) {
	Dictionary<int,int> hashMap=new Dictionary<int,int>();
	for(int i=0;i<nums.Length;i++)
	{
		int restOfSum=target-nums[i];
		if(hashMap.ContainsKey(restOfSum))
		{
			return new int[]{hashMap[restOfSum],i};
		}
		hashMap[nums[i]]=i;
	}
	return new int[0];
}
