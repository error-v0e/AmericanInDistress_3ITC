using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileData TileData { get; set; }
    public GameObject buildingPrefab;

    internal void SetBuilding(GameObject building)
    {
        building.transform.SetParent(transform);
        building.transform.localPosition = new Vector3(1.25f, 0.5f, 1.25f);
    }

    private void OnMouseDown()
    {
        if (buildingPrefab != null)
        {
            var building = Instantiate(buildingPrefab);
            SetBuilding(building);

            var cmd = new BuildCommand(
                building, 
                this
            );

            CommandQueue.Instance.AddCommand(cmd);
        }
        else
        {
            Debug.LogWarning("Prefab budovy není nastaven!");
        }
    }
}
