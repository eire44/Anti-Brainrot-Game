using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodesPath : MonoBehaviour
{
    public NodesPath[] nextNodes;
    public int selectedIndex = 0;

    public NodesPath GetNextNode()
    {
        if (nextNodes.Length == 0) return null;
        return nextNodes[selectedIndex];
    }

    public void ToggleDirection()
    {
        if (nextNodes.Length <= 1) return;
        selectedIndex = (selectedIndex + 1) % nextNodes.Length;
    }

    void OnMouseDown()
    {
        ToggleDirection();
    }
}
