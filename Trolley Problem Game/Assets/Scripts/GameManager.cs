using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text stationName;
    public TMP_Text victimsCount;
    public TMP_Text savedCount;
    int amountOfVictims = 0;
    int amountSaved = 0;
    [HideInInspector] public string destinyName = "";
    // Start is called before the first frame update
    void Start()
    {
        Station_Controller[] stations = FindObjectsOfType<Station_Controller>();
        int index = Random.Range(0, stations.Length);
        stations[index].isGoal = true;
        destinyName = stations[index].stationName;

        stationName.text = "Next Station is: " + destinyName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToVictimsCount()
    {
        amountOfVictims++;
        victimsCount.text = "Killed: " + amountOfVictims.ToString();
    }

    public void addToSavedCount(int amountToSave)
    {
        amountSaved += amountToSave;
        savedCount.text = "Saved: " + amountSaved.ToString();
    }

    void CheckStation(NodesPath node)
    {
        Station_Controller station = node.GetComponent<Station_Controller>();
        if (station != null && station.isGoal)
        {
            //que presione stop train
            Debug.Log("Ganaste");
        }
    }
}
