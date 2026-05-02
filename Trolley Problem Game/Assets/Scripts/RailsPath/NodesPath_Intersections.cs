using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class NodesPath_Intersections : NodesPath
{
    public List<IntersectionToVictim> intersectionToVictims = new List<IntersectionToVictim>();
    bool changeTrack = true;
    int amountSaved = 0;
    private void Start()
    {
        showSelectedTrail();
    }

    public override NodesPath GetNextNode()
    {
        if (intersectionToVictims.Count == 0) return null;
        return intersectionToVictims[selectedIndex].nextNode;
    }

    public void ToggleDirection()
    {
        if (intersectionToVictims.Count <= 1) return;
        selectedIndex = (selectedIndex + 1) % intersectionToVictims.Count;


        showSelectedTrail();
    }

    void showSelectedTrail()
    {
        foreach (IntersectionToVictim item in intersectionToVictims)
        {
            float alpha = 1;
            if (item.trailID != selectedIndex)
            {
                alpha = 0.4f;
                amountSaved = item.trackVictims;
            }

            SpriteRenderer sr = item.trailOption.GetComponent<SpriteRenderer>();

            Color c = sr.color;
            c.a = alpha;
            sr.color = c;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("PRESSED");
        if(changeTrack)
        {
            ToggleDirection();
        }

        //it could have an alert text saying it´s too late
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            changeTrack = false;
            FindObjectOfType<GameManager>().addToSavedCount(amountSaved);

            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

            Color c = sr.color;
            c.a = 0f;
            sr.color = c;
        }
    }
}
