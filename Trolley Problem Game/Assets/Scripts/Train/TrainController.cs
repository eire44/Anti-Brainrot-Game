using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public NodesPath currentNode;
    private NodesPath targetNode; 

    public float speed = 2f;
    private float t = 0f;

    void Start()
    {
        targetNode = currentNode.GetNextNode();
    }

    void Update()
    {
        if (targetNode == null) return;

        t += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(currentNode.transform.position, targetNode.transform.position, t);

        if (t >= 1f)
        {
            currentNode = targetNode;
            targetNode = currentNode.GetNextNode();
            t = 0f;
        }
    }
}
