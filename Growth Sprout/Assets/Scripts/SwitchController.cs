using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
	public static SwitchController instance = null;
	public bool isOn;
	public bool powerup = false;
	float timeLastShot = 0f;
	float delayBetweenShots = 1f;

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
		if (Input.GetKeyDown(KeyCode.UpArrow) && (Time.time > timeLastShot + delayBetweenShots))
        {
			timeLastShot = Time.time;
			isOn = !isOn;

		}
    }

    public void FlipSwitch()
	{
		isOn = !isOn;
	}

	public void TurnTrue()
    {
		powerup = true;
    }

	public void FlipSwitch2()
	{
		if(powerup == true)
        {
			isOn = !isOn;
		}
		
	}
}
