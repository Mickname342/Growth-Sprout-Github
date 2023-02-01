using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectScript : MonoBehaviour
{
    public UnityEvent interact;
    public Transform seed;
    public Transform Player;
    public bool collectable = false;
    public bool collected = false;

    private void Update()
    {
        if (collected == true)
        {
            seed.position = Player.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collectable == true && collision.CompareTag("Player"))
        {
            collected = true;
            print(collision);
        }
        

    }
}
