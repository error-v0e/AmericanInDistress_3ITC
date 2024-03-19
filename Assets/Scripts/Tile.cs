using UnityEngine;

public class Tile : MonoBehaviour
{
    viewmanagement view;
    public TileData TileData { get; set; }
    public GameObject buildingPrefab; // Prom�nn� pro ulo�en� prefabu

    internal void SetBuilding(GameObject building)
    {
        building.transform.SetParent(transform);
        building.transform.localPosition = new Vector3(1.28f, 0.8f, 1.19f);
    }

    void Awake()
    {
        view = FindObjectOfType<viewmanagement>();
    }

    private void OnMouseDown()
    {
        if (view != null && (view.wood > 0 || view.money > 0))
        {
            // Kontrola, zda je nastaven prefab
            if (buildingPrefab != null)
            {
                // Spawnout prefab m�sto kostky
                var building = GameObject.Instantiate(buildingPrefab);
                var cmd = new BuildCommand(
                    building,
                    this,
                    view
                );
                CommandQueue.Instance.AddCommand(cmd);
            }
            else
            {
                Debug.LogWarning("Prefab pro stavbu nen� nastaven.");
            }
        }
        else
        {
            Debug.LogWarning("Nen� dostatek d�eva nebo pen�z pro spawn stavby.");
        }
    }
}
