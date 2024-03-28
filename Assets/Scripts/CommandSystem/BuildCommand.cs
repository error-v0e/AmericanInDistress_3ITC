using Unity.VisualScripting;
using UnityEngine;

public class BuildCommand : Command
{
    private GameObject buildingPrefab;
    private GameObject buildingPrefab2;
    private Tile tile;
    private viewmanagement view;
    private int lastPressedButton;

    public BuildCommand(GameObject buildingPrefab, GameObject buildingPrefab2, Tile tile, viewmanagement view, int lastPressedButton)
    {
        this.buildingPrefab = buildingPrefab;
        this.buildingPrefab2 = buildingPrefab2;
        this.tile = tile;
        this.view = view;
        this.lastPressedButton = lastPressedButton;
    }

    public override void Execute()
    {
        if (lastPressedButton == 1)
        {
            if (view != null)
            {
                view.RemoveMoney(100);
                view.RemoveWood(100);
            }
            else
            {
                Debug.LogWarning("View is not set.");
            }

            var building = GameObject.Instantiate(buildingPrefab);
            tile.SetBuilding(building);
        }
        else if (lastPressedButton == 2)
        {
            if (view != null)
            {
                view.RemoveMoney(200);
                view.RemoveWood(200);
            }
            else
            {
                Debug.LogWarning("View is not set.");
            }

            var building = GameObject.Instantiate(buildingPrefab2);
            tile.SetBuilding(building);
        }
    }
}
