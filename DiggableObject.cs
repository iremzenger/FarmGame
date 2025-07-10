using UnityEngine;

public class DiggableObject : MonoBehaviour
{

    public GameObject dugVersion; // Kaz�lm�� versiyon prefab�

    private void OnMouseDown()
    {
        ToolbarManager toolBar=FindObjectOfType<ToolbarManager>();
        if (toolBar.currentTool == ToolbarManager.SelectedTool.Shovel)
        {
            Instantiate(dugVersion, transform.position, transform.rotation);
            Destroy(gameObject); // Kaz�ld�ktan sonra mevcut nesneyi yok et
        }
    }
}
