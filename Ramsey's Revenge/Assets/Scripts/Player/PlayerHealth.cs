﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int numOfHearts;
    public GameObject playerCamera;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    //private bool ram = false;

    // Start is called before the first frame update
    void Start()
    {
        health = 100; // default health
    }

    // Update is called once per frame
    void Update()
    {
        //checks for death
        //if (health <= 0)
        //{
        //    Destroy(gameObject);
        //}
        if (health <= 0)
        {
            gameObject.transform.position = new Vector3(-155f, 40f, 0f);
            playerCamera.transform.position = new Vector3(-80.9f, 103.2f, -1f);
            health = 100;
        }

        if (health/25 > numOfHearts)
        {
            health = numOfHearts * 25;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health/25)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    //can be called by enemies
    public void PlayerTakesDamage(int damage)
    {
        health -= damage;
        this.gameObject.GetComponent<Animator>().Play("DamageTaken");
    }
}
