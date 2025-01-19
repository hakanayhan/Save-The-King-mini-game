using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int x, y;
    private GridManager gridManager;
    public GridManager.Color color;
    public void Initialize(int x, int y, GridManager manager, GridManager.Color color)
    {
        this.x = x;
        this.y = y;
        this.gridManager = manager;
        this.color = color;
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
