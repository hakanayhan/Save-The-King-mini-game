using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 8;
    public int height = 6;
    public GameObject tilePrefab;

    public enum Color
    {
        Red,
        Blue,
        Green
    }

    public List<Color> colors;

    public Vector2 tileSize = new Vector2(1, 1);
    public float spacing;
    private GameObject[,] grid;

    void Start()
    {
        grid = new GameObject[width, height];
        GenerateTile();
    }

    void GenerateTile()
    {
        float startX = -width / 2 * (tileSize.x + spacing) + gameObject.GetComponent<Transform>().position.x * 2;
        float startY = -height / 2 * (tileSize.y + spacing) + gameObject.GetComponent<Transform>().position.y * 2;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 position = new Vector2(startX + x * (tileSize.x + spacing), startY + y * (tileSize.y + spacing));
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
                tile.transform.parent = transform;
                tile.transform.localScale = new Vector3(tileSize.x, tileSize.y, 1);
                grid[x, y] = tile;
                Color randomColor = colors[Random.Range(0, colors.Count)];

                tile.GetComponent<Tile>().Initialize(x, y, this, randomColor);
            }
        }
    }
}