using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Build", order = 1)]
public class Build : ScriptableObject
{
    public Builds[] builds; // Array of Build objects

    [System.Serializable]
    public class Builds
    {
        public int cena;
        public int cenaDrevo;
        public GameObject building;
    }
}