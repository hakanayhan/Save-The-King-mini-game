using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int x, y;
    private GridManager gridManager;
    public GridManager.Color color;
    [SerializeField] private GameObject circle;

    private Dictionary<GridManager.Color, Color> colorMapping = new Dictionary<GridManager.Color, Color>
        {
            { GridManager.Color.Red, Color.red },
            { GridManager.Color.Blue, Color.blue },
            { GridManager.Color.Green, Color.green }
        };

    public void Initialize(int x, int y, GridManager manager, GridManager.Color color)
    {
        this.x = x;
        this.y = y;
        this.gridManager = manager;
        this.color = color;
        SetColor();
    }

    private void SetColor()
    {
        circle.GetComponent<SpriteRenderer>().color = colorMapping[color];
    }

    private void OnMouseDown()
    {
        Debug.Log($"Tile selected at ({x}, {y})");
    }

    private void OnMouseUp()
    {
        Debug.Log("Tile released");
    }
}
