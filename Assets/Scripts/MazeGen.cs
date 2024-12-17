using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public int width = 10;
    public int height = 10;
    public float wallSpacing = 6f;

    private int[,] maze;

    private void Start()
    {
        maze = new int[width, height];
        GenerateMaze();
    }

    void GenerateMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                maze[x, y] = 1;
            }
        }

        CarvePath(1, 1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (maze[x, y] == 1)
                {
                    Vector3 position = new Vector3(x * wallSpacing, y * wallSpacing, 0);
                    Instantiate(wallPrefab, position, Quaternion.identity);
                }
            }
        }
    }

    void CarvePath(int x, int y)
    {
        maze[x, y] = 0;

        List<Vector2Int> directions = new List<Vector2Int>
        {
            new Vector2Int(0, 1),  
            new Vector2Int(1, 0),   
            new Vector2Int(0, -1),  
            new Vector2Int(-1, 0)   
        };

        for (int i = 0; i < directions.Count; i++)
        {
            var temp = directions[i];
            int randomIndex = Random.Range(i, directions.Count);
            directions[i] = directions[randomIndex];
            directions[randomIndex] = temp;
        }

        foreach (var direction in directions)
        {
            int newX = x + direction.x * 2;
            int newY = y + direction.y * 2;

            if (newX >= 1 && newX < width - 1 && newY >= 1 && newY < height - 1 && maze[newX, newY] == 1)
            {
                maze[x + direction.x, y + direction.y] = 0;
                CarvePath(newX, newY);
            }
        }
    }
}
