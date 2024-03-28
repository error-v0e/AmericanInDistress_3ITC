using UnityEngine;

public class Tile : MonoBehaviour
{
    private viewmanagement view;
    private bool isMouseDown = false;
    private float lastSpawnTime = 0f;
    private float spawnCooldown = 1f; // Cooldown pro spawnování kostiček

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
        if (!isMouseDown && Time.time - lastSpawnTime >= spawnCooldown)
        {
            isMouseDown = true;
            lastSpawnTime = Time.time;

            if (view != null && (view.wood > 0 || view.money > 0))
            {
                SpawnBuilding(); // Spawnovat prefab a odečíst peníze
            }
            else
            {
                Debug.LogWarning("Není dostatek dřeva nebo peněz pro spawn stavby.");
            }
        }
    }

    private void SpawnBuilding()
    {
        if (buildingPrefab != null && buildingPrefab2 != null)
        {
            Debug.Log("stavise " + lastPressedButton);
            var building = GameObject.Instantiate(buildingPrefab);
            var building2 = GameObject.Instantiate(buildingPrefab2);
            var cmd = new BuildCommand(
                building,
                building2,
                this,
                view,
                lastPressedButton);
            CommandQueue.Instance.AddCommand(cmd);
            if (lastPressedButton == 1)
            {
                view.RemoveMoney(100);
                view.RemoveWood(100);
            }
            else if (lastPressedButton == 2)
            {
                view.RemoveMoney(200);
                view.RemoveWood(200);
            }
        }
        else
        {
            Debug.LogWarning("Prefab pro stavbu není nastaven.");
        }
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
    }
}
