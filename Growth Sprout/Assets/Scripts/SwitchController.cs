using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
	public static SwitchController instance = null;
	public bool isOn = false;
	float timeLastShot = 0f;
	float delayBetweenShots = 1f;
	public UnityEvent past;
	public UnityEvent future;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

    private void Update()
    {
		if (Time.time > timeLastShot + delayBetweenShots)
        {
			if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
            {
				timeLastShot = Time.time;
				isOn = !isOn;
				past.Invoke();
				return;
			}
			
		}
		if (isOn)
        {
			
        }
		if (!isOn)
        {
			future.Invoke();
        }
    }

}
