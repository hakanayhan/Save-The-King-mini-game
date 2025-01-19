using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x, y;
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
    private void OnMouseUp()
    {
        Tile targetTile = GetTileUnderMouse();

        if (targetTile != null && IsNeighbor(targetTile))
        {
            gridManager.SwapTiles(this, targetTile);
        }
    }
    private Tile GetTileUnderMouse()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            return hit.collider.GetComponent<Tile>();
        }

        return null;
    }
    private bool IsNeighbor(Tile other)
    {
        return (Mathf.Abs(this.x - other.x) == 1 && this.y == other.y) ||
               (Mathf.Abs(this.y - other.y) == 1 && this.x == other.x);
    }
    public void UpdatePosition(int newX, int newY)
    {
        x = newX;
        y = newY;
    }
}
