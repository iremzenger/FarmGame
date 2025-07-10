using UnityEngine;

public class SoilFieldGenerator : MonoBehaviour
{
    [Header("Toprak Ayarlar�")]
    public GameObject soilPrefab; // Yerle�tirilecek toprak prefab'�
    public int width = 5;         // X y�n�nde ka� tile
    public int height = 5;        // Z y�n�nde ka� tile
    public float spacing = 1.0f;  // Tile'lar aras� bo�luk

    [Header("Alan Konumu")]
    public Vector3 center = Vector3.zero; // Alan�n merkezi

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
