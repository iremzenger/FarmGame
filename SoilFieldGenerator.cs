using UnityEngine;

public class SoilFieldGenerator : MonoBehaviour
{
    [Header("Toprak Ayarlarý")]
    public GameObject soilPrefab; // Yerleþtirilecek toprak prefab'ý
    public int width = 5;         // X yönünde kaç tile
    public int height = 5;        // Z yönünde kaç tile
    public float spacing = 1.0f;  // Tile'lar arasý boþluk

    [Header("Alan Konumu")]
    public Vector3 center = Vector3.zero; // Alanýn merkezi

    void Start()
    {
        GenerateSoilField();
    }

    void GenerateSoilField()
    {
        Vector3 origin = center - new Vector3(width / 2f * spacing, 0, height / 2f * spacing);

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = origin + new Vector3(x * spacing, 0, z * spacing);
                Instantiate(soilPrefab, pos, Quaternion.identity, transform);
            }
        }
    }
}
