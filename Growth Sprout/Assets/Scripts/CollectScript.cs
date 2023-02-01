using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectScript : MonoBehaviour
{
    public UnityEvent NotChange;
    public UnityEvent Change;
    public UnityEvent InsidePot;
    public UnityEvent OutsidePot;
    public Transform seed;
    public Transform Player;
    public bool collectable = false;
    public bool collected = false;

    private void Update()
    {
        if (collected == true)
        {
            seed.position = Player.position + new Vector3(0,0.5f,0);
        }
        if (collected == true && Input.GetKey(KeyCode.DownArrow))
        {
            collected = false;
        }
        if (collected == false)
        {
            Change.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collectable == true && collision.CompareTag("Player"))
        {
            NotChange.Invoke();
            collected = true;
            print(collision.gameObject);
        }
        if (collision.CompareTag("Pot"))
        {
            InsidePot.Invoke();
            print(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pot"))
        {
            OutsidePot.Invoke();
        }
    }
}
