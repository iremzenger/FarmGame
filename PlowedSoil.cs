using UnityEngine;

public class PlowedSoil : MonoBehaviour
{
    private float holdTime = 0f;
    public float holdThreshold = 0.6f; // Ka� saniye bas�l� tutulunca men� a��ls�n

    private bool isHolding = false;


    public GameObject tomatoPlant;
    public GameObject wheatPlant;
    public GameObject sunflowerPlant;

    void OnMouseDown()
    {
        isHolding = true;
        holdTime = 0f;
    }

    void OnMouseUp()
    {
        isHolding = false;
    }

    void Update()
    {
        if (isHolding)
        {
            holdTime += Time.deltaTime;
            if (holdTime >= holdThreshold)
            {
                isHolding = false; // bir kez a� sonra bekleme
                OpenSeedMenu();
            }
        }
    }

    void OpenSeedMenu()
    {
        // Men� sistemini �a��r
        SeedMenu.Instance.OpenMenuAtPosition(transform.position, this);
    }


    public void ShowCrop(string seedType)
    {
        GameObject plant = null;

        switch (seedType)
        {
            case "Tomato":
                plant = Instantiate(tomatoPlant, transform.position, Quaternion.identity);
                break;
            case "Wheat":
                plant = Instantiate(wheatPlant, transform.position, Quaternion.identity);
                break;
            case "Sunflower":
                plant = Instantiate(sunflowerPlant, transform.position, Quaternion.identity);
                break;
        }
    }
}
