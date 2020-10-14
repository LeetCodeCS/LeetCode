// https://leetcode.com/problems/flood-fill/
// Easy
/*
An image is represented by a 2-D array of integers, each integer representing the pixel value of the image (from 0 to 65535).

Given a coordinate (sr, sc) representing the starting pixel (row and column) of the flood fill, and a pixel value newColor, "flood fill" the image.

To perform a "flood fill", consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, plus any pixels connected 4-directionally to those pixels (also with the same color as the starting pixel), and so on. Replace the color of all of the aforementioned pixels with the newColor.

At the end, return the modified image.

Example 1:
Input: 
image = [[1,1,1],[1,1,0],[1,0,1]]
sr = 1, sc = 1, newColor = 2
Output: [[2,2,2],[2,2,0],[2,0,1]]
Explanation: 
From the center of the image (with position (sr, sc) = (1, 1)), all pixels connected 
by a path of the same color as the starting pixel are colored with the new color.
Note the bottom corner is not colored 2, because it is not 4-directionally connected
to the starting pixel.
Note:

The length of image and image[0] will be in the range [1, 50].
The given starting pixel will satisfy 0 <= sr < image.length and 0 <= sc < image[0].length.
The value of each color in image[i][j] and newColor will be an integer in [0, 65535].
*/

// floodfill
public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
        if(image[sr][sc]==newColor) return image;
        int oldColor=image[sr][sc];
        image[sr][sc]=newColor;
        Point epicenter=new Point(sr,sc);
        Queue<Point> point=new Queue<Point>();
        point.Enqueue(epicenter);
        while(point.Count>0)
        {
            epicenter=point.Dequeue();

            for(int i=0;i<epicenter.dir.Length;i++)
            {
                int row = epicenter.x + epicenter.dir[i][0];
                int col = epicenter.y + epicenter.dir[i][1];
                if(row>=0 && row<image.Length && col>=0 && col<image[0].Length && image[row][col]==oldColor )
                {
                    image[row][col]=newColor;                   
                    point.Enqueue(new Point(row,col));
                }
            }  
        }
        return image;
        
    }
    public class Point
    {
        public int x {get;set;}
        public int y {get;set;}
        public int[][] dir = new int[4][];

        public Point(int r, int c)
        {
            x=r;
            y=c;
            dir[0] = new int[] { 0, 1 };
            dir[1] = new int[] { 0, -1 };
            dir[2] = new int[] { 1, 0 };
            dir[3] = new int[] { -1, 0 };
        }
    }
}
