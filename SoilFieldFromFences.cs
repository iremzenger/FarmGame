using UnityEngine;

public class SoilFieldFromFences : MonoBehaviour
{
    public GameObject fenceParent;   // FenceGroup atanacak
    public GameObject soilPrefab;
    public float spacing = 1f;

    private void Start()
    {
        Bounds bounds = CalculateBounds(fenceParent);
        GenerateSoilInBounds(bounds);
    }

    Bounds CalculateBounds(GameObject parent)
    {
        Renderer[] renderers = parent.GetComponentsInChildren<Renderer>();
        Bounds bounds = renderers[0].bounds;

        foreach (Renderer r in renderers)
        {
            bounds.Encapsulate(r.bounds);
        }

        return bounds;
    }

    void GenerateSoilInBounds(Bounds bounds)
    {
        Vector3 start = new Vector3(bounds.min.x + spacing / 2f, bounds.min.y, bounds.min.z + spacing / 2f);
        Vector3 end = bounds.max;

        for (float x = start.x; x < end.x; x += spacing)
        {
            for (float z = start.z; z < end.z; z += spacing)
            {
                Vector3 pos = new Vector3(x, bounds.min.y, z);
                Instantiate(soilPrefab, pos, Quaternion.identity, transform);
            }
        }
    }
}
