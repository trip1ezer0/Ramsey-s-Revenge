using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void startFight()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void endFight()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}
