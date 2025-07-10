
using UnityEngine;

public class SingleTilePainter : MonoBehaviour
{
    public Terrain terrain;
    public int dryDirtLayerIndex = 1; // DryDirt katmanýnýn sýrasý (Inspector'dan kontrol edin)

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ToolbarManager.Instance.currentTool == ToolbarManager.SelectedTool.Shovel)
        {
            PaintSingleTile();
        }
    }

    void PaintSingleTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider is TerrainCollider)
        {
            // Terrain'in local pozisyonunu al
            Vector3 localPos = hit.point - terrain.transform.position;

            // Alphamap koordinatlarýný hesapla
            int alphamapWidth = terrain.terrainData.alphamapWidth;
            int alphamapHeight = terrain.terrainData.alphamapHeight;

            int x = Mathf.FloorToInt((localPos.x / terrain.terrainData.size.x) * alphamapWidth);
            int y = Mathf.FloorToInt((localPos.z / terrain.terrainData.size.z) * alphamapHeight);

            // Sadece 1x1'lik alaný boya
            float[,,] alphaMap = terrain.terrainData.GetAlphamaps(x, y, 1, 1);

            // Tüm katmanlarý sýfýrla, sadece dryDirtLayerIndex'i 1 yap
            for (int layer = 0; layer < terrain.terrainData.terrainLayers.Length; layer++)
            {
                alphaMap[0, 0, layer] = (layer == dryDirtLayerIndex) ? 1f : 0f;
            }

            terrain.terrainData.SetAlphamaps(x, y, alphaMap);
        }
    }
}
