using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodesPath : MonoBehaviour
{
    public NodesPath nextNode;
    [HideInInspector] public int selectedIndex = 0;

    public virtual NodesPath GetNextNode()
    {
        return nextNode;
    }
}
