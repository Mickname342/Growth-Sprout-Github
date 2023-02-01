using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlock : MonoBehaviour
{

	private bool isOn;
	public BoxCollider2D col1;
	public BoxCollider2D col2;
	private SpriteRenderer spriteR;
	public SwitchController SwitchController;
	public Sprite OnSprite;
	public Sprite OffSprite;
	//private Color semiVisible;
	private bool setOn;
	private bool setOff;

	// Use this for initialization
	void Start()
	{
		//col = GetComponent<BoxCollider2D>();
		spriteR = GetComponent<SpriteRenderer>();
		//semiVisible = new Color(1, 1, 1, 0.5f);
		setOn = true;
		setOff = false;
	}

	// Update is called once per frame
	void Update()
	{
		isOn = SwitchController.instance.isOn;

		if (!setOn)
		{
			if (isOn)
			{
				col1.enabled = true;
				col2.enabled = false;
				spriteR.sprite = OnSprite;
				spriteR.color = Color.white;
				setOn = true;
				setOff = false;
			}

		}
		if (!setOff)
		{
			if (!isOn)
			{
				col1.enabled = false;
				col2.enabled = true;
				spriteR.sprite = OffSprite;
				//spriteR.color = Color.white;
				setOff = true;
				setOn = false;
			}
		}
	}
}
