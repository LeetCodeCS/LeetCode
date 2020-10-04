// https://leetcode.com/problems/rotting-oranges/
// Medium
/*
In a given grid, each cell can have one of three values:

the value 0 representing an empty cell;
the value 1 representing a fresh orange;
the value 2 representing a rotten orange.
Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.

Return the minimum number of minutes that must elapse until no cell has a fresh orange.  If this is impossible, return -1 instead.

 

Example 1:



Input: [[2,1,1],[1,1,0],[0,1,1]]
Output: 4
Example 2:

Input: [[2,1,1],[0,1,1],[1,0,1]]
Output: -1
Explanation:  The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.
Example 3:

Input: [[0,2]]
Output: 0
Explanation:  Since there are already no fresh oranges at minute 0, the answer is just 0.
 

Note:

1 <= grid.length <= 10
1 <= grid[0].length <= 10
grid[i][j] is only 0, 1, or 2.
Accepted
*/

// time: O(n), space O(n)
public int OrangesRotting(int[][] grid) {
	if(grid==null || grid.Length==0) return -1;  
	int min=0;
	const int EMPTY=0;  // easier to remember
	const int FRESH=1;
	const int ROTTEN=2;
	int gridSize=grid.Length*grid[0].Length;  
	int rottenCount=0;
	int freshCount=0;
	int emptyCount=0;
	
	// we gonna do BFS, so a queue would help
	Queue<Point> rottenQueue=new Queue<Point>();
	for(int i=0;i<grid.Length;i++)
	{
		for(int j=0;j<grid[i].Length;j++)
		{
			switch(grid[i][j])
			{   // get some stats to avoid edge cases, also enqueue rotten oranges
				case ROTTEN:
					rottenQueue.Enqueue(new Point(i,j));
					rottenCount++;
					break;
				case FRESH:
					freshCount++;
					break;
				case EMPTY:
					emptyCount++;
					break;
				default:
					break;
			}
		}
	}
	// possible edge cases
	if(rottenCount==gridSize) return 0;
	if(freshCount==gridSize) return -1;
	if(emptyCount==gridSize) return 0;
	if(rottenCount==0) return -1;
	// to know when to stop if orange is far away
	bool rottingHappen=false;
	// while we can make other oranges rotten ...
	while(rottenQueue.Count>0 && freshCount>0)
	{   // to prevent rotting chaining in same minute
		int rottenCountBefore=rottenQueue.Count;
		rottingHappen=false;
		while(rottenCountBefore>0)
		{   
			Point rottenOrange=rottenQueue.Dequeue();
			rottenCountBefore--;
			int row=-1;
			int col=-1;
			// 4 directions, top,bottom,left,right
			for(int i=0;i<rottenOrange.dir.Length;i++)
			{
				row=rottenOrange.dir[i][0];
				col=rottenOrange.dir[i][1];
				if(row<grid.Length && row>=0 &&
				   col<grid[0].Length && col>=0 && grid[row][col]==FRESH)
				{
					grid[row][col]=ROTTEN;
					rottenQueue.Enqueue(new Point(row,col));
					freshCount--;
					rottenCount++;
					rottingHappen=true;
				} 
			}

		}// if no rotting happened last round and there is still fresh oranges, then its impossible
		if(!rottingHappen && freshCount!=0) return -1;
	
		min++;     
	}
	return min;   
}
public class Point
{
	public int row {set;get;}
	public int col {set;get;}
	public int [][] dir{get;set;}
	public Point(int r, int c)
	{
		row=r;
		col=c;
		dir=new int[4][];
		dir[0]=new int[]{row+1,col};
		dir[1]=new int[]{row-1,col};
		dir[2]=new int[]{row,col+1};
		dir[3]=new int[]{row,col-1};   
	}
}
