using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PotScript : MonoBehaviour
{
    public UnityEvent InsidePot;
    public UnityEvent OutsidePot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Plant"))
        {
            InsidePot.Invoke();
        }
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Plant"))
        {
            OutsidePot.Invoke();
        }
    }

}
