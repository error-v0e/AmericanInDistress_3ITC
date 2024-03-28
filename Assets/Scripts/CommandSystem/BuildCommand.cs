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

            var building = GameObject.Instantiate(buildingPrefab);
            tile.SetBuilding(building);
        }
        else if (lastPressedButton == 2)
        {

            var building = GameObject.Instantiate(buildingPrefab2);
            tile.SetBuilding(building);
        }
    }
}
