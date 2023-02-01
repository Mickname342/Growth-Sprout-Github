using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
	public static SwitchController instance = null;
	public bool isOn = false;
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
		if (Input.GetKeyDown(KeyCode.Return) && (Time.time > timeLastShot + delayBetweenShots))
        {
			timeLastShot = Time.time;
			isOn = !isOn;
			return;
		}
    }

}
