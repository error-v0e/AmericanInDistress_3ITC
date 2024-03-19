using Unity.VisualScripting;
using UnityEngine;

public class BuildCommand : Command
{
    private GameObject buildingPrefab;
    private Tile tile;
    private viewmanagement view;

    public BuildCommand(GameObject buildingPrefab, Tile tile, viewmanagement view)
    {
        this.buildingPrefab = buildingPrefab;
        this.tile = tile;
        this.view = view;
    }

    public override void Execute()
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
}
