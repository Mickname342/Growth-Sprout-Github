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
    public GameObject PlayerTagger;
    public bool collectable = false;
    public bool collected = false;
    public float offset = 0.5f;
    public bool past = true;
    public bool droppedThisFrame = false;

    private void Update()
    {
        if (collected == true)
        {
            seed.position = Player.position + new Vector3(0,offset,0);
        }
        if (collected == true && Input.GetKey(KeyCode.DownArrow))
        {
            collected = false;
            droppedThisFrame = true;
        }
        if (collected == false && droppedThisFrame)
        {
            if (past)
            {
                OutsidePot.Invoke();
            }
            Change.Invoke();
            droppedThisFrame = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collectable == true && collision.CompareTag("Player"))
        {
            NotChange.Invoke();
            collected = true;
            InsidePot.Invoke();
        }
    }

    public void ChangeTime()
    {
        past = !past;
    }
}
