using UnityEngine;

public class ToolbarManager : MonoBehaviour
{
    public enum SelectedTool { None,Shovel, Pickaxe, WaterCan }
    public SelectedTool currentTool = SelectedTool.None;

    public static ToolbarManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    public void SelectShovel()
    {
        currentTool = SelectedTool.Shovel;
        Debug.Log("Shovel selected");
    }

    public void SelectPickaxe()
    {
        currentTool = SelectedTool.Pickaxe;
        Debug.Log("Pickaxe selected");
    }

    public void SelectWaterCan()
    {
        currentTool = SelectedTool.WaterCan;
        Debug.Log("WaterCan selected");
    }
}
