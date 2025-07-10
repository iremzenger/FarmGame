using UnityEngine;

public class TerrainResetManager : MonoBehaviour
{
    public Terrain terrain;

    void Start()
    {
        ResetTerrain();
    }

    public void ResetTerrain()
    {
        // T�m alphamap'leri s�f�rla (sadece �im g�z�kecek)
        float[,,] alphaMaps = terrain.terrainData.GetAlphamaps(0, 0,
            terrain.terrainData.alphamapWidth,
            terrain.terrainData.alphamapHeight);

        for (int x = 0; x < terrain.terrainData.alphamapWidth; x++)
        {
            for (int y = 0; y < terrain.terrainData.alphamapHeight; y++)
            {
                alphaMaps[x, y, 0] = 1f; // Grass layer = 1
                for (int l = 1; l < terrain.terrainData.terrainLayers.Length; l++)
                {
                    alphaMaps[x, y, l] = 0f; // Di�er katmanlar = 0
                }
            }
        }
        terrain.terrainData.SetAlphamaps(0, 0, alphaMaps);

        Debug.Log("Terrain s�f�rland�!");
    }
}
