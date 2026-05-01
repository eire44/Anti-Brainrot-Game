using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text stationName;
    // Start is called before the first frame update
    void Start()
    {
        Station_Controller[] stations = FindObjectsOfType<Station_Controller>();
        int index = Random.Range(0, stations.Length);
        stations[index].isGoal = true;

        stationName.text = "Next Station is: " + stations[index].name;
    }

    // Update is called once per frame
    void Update()
    {
        
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
