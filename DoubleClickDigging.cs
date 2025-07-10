using System.Collections.Generic;
using UnityEngine;

public class DoubleClickDigging : MonoBehaviour
{
    public Terrain terrain;
    private Dictionary<Vector2Int, int> tileStates = new Dictionary<Vector2Int, int>();
    private float doubleClickTime = 0.3f;
    private float lastClickTime;
    private Vector2Int lastClickedTile;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ToolbarManager.Instance.currentTool == ToolbarManager.SelectedTool.Shovel)
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        Vector2Int currentTile = GetCurrentTile();

        // Çift týklama kontrolü
        if (currentTile == lastClickedTile && (Time.time - lastClickTime) < doubleClickTime)
        {
            AdvanceTileState(currentTile);
        }
        else
        {
            // Yeni týklama baþlat
            tileStates[currentTile] = 1;
            PaintTile(currentTile, 1); // Sand layer
        }

        lastClickTime = Time.time;
        lastClickedTile = currentTile;
    }

    void AdvanceTileState(Vector2Int tile)
    {
        if (!tileStates.ContainsKey(tile)) tileStates[tile] = 0;
        tileStates[tile]++;

        if (tileStates[tile] == 2) // DryDirt
        {
            PaintTile(tile, 2);
        }
        else if (tileStates[tile] > 2) // Reset to grass
        {
            tileStates[tile] = 0;
            PaintTile(tile, 0);
        }
    }

    Vector2Int GetCurrentTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider is TerrainCollider)
        {
            Vector3 localPos = hit.point - terrain.transform.position;
            int x = Mathf.FloorToInt((localPos.x / terrain.terrainData.size.x) * terrain.terrainData.alphamapWidth);
            int y = Mathf.FloorToInt((localPos.z / terrain.terrainData.size.z) * terrain.terrainData.alphamapHeight);
            return new Vector2Int(x, y);
        }
        return new Vector2Int(-1, -1);
    }

    void PaintTile(Vector2Int tile, int layerIndex)
    {
        float[,,] alphaMap = terrain.terrainData.GetAlphamaps(tile.x, tile.y, 1, 1);
        for (int i = 0; i < terrain.terrainData.terrainLayers.Length; i++)
        {
            alphaMap[0, 0, i] = (i == layerIndex) ? 1f : 0f;
        }
        terrain.terrainData.SetAlphamaps(tile.x, tile.y, alphaMap);
    }
}
