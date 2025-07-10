using UnityEngine;

public class SeedMenu : MonoBehaviour
{
    public static SeedMenu Instance;

    public GameObject menuUI; // Men� paneli (Canvas alt�nda olmal�)
    private PlowedSoil currentSoil;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        menuUI.SetActive(false); // Ba�ta gizli
    }

    public void OpenMenuAtPosition(Vector3 worldPosition, PlowedSoil soil)
    {
        currentSoil = soil;

        // Men� konumunu world'den screen'e �evir
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        menuUI.transform.position = screenPos;

        menuUI.SetActive(true);
    }

    public void PlantSeed(string seedType)
    {
        if (currentSoil != null)
        {
            currentSoil.ShowCrop(seedType);
        }

        menuUI.SetActive(false);
    }

    public void CloseMenu()
    {
        menuUI.SetActive(false);
    }
}
