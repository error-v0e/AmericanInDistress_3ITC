using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    viewmanagement view;
    public TileData TileData { get; set; }
    public GameObject buildingPrefab;
    public GameObject buildingPrefab2;
    private static int lastPressedButton = 1;

    public void OnButton1Pressed()
    {
        lastPressedButton = 1;
        Debug.Log("Button 1 pressed");
        Debug.Log("pressed " + lastPressedButton);
    }

    public void OnButton2Pressed()
    {
        lastPressedButton = 2;
        Debug.Log("Button 2 pressed");
        Debug.Log("pressed " + lastPressedButton);
    }


    internal void SetBuilding(GameObject building)
    {
        building.transform.SetParent(transform);
        building.transform.localPosition = new Vector3(1.25f, 0.5f, 1.25f);
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
            if (buildingPrefab != null && buildingPrefab2 != null)
            {
                Debug.Log("stavise " + lastPressedButton);
                // Spawnout prefab místo kostky
                var building = GameObject.Instantiate(buildingPrefab);
                var building2 = GameObject.Instantiate(buildingPrefab2);
                var cmd = new BuildCommand(
                    building,
                    building2,
                    this,
                    view,
                    lastPressedButton);
                CommandQueue.Instance.AddCommand(cmd);
            }
            else
            {
                Debug.LogWarning("Prefab pro stavbu není nastaven.");
            }
        }
        else
        {
            Debug.LogWarning("Není dostatek døeva nebo penìz pro spawn stavby.");
        }
    }
}
