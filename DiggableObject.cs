using UnityEngine;

public class DiggableObject : MonoBehaviour
{

    public GameObject dugVersion; // Kazýlmýþ versiyon prefabý

    private void OnMouseDown()
    {
        ToolbarManager toolBar=FindObjectOfType<ToolbarManager>();
        if (toolBar.currentTool == ToolbarManager.SelectedTool.Shovel)
        {
            Instantiate(dugVersion, transform.position, transform.rotation);
            Destroy(gameObject); // Kazýldýktan sonra mevcut nesneyi yok et
        }
    }
}
