using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour
{

	private bool isOn;
	public Collider2D col1;
	public Collider2D col2;
	private SpriteRenderer spriteR;
	public Sprite OnSprite;
	public Sprite OffSprite;
	public SpriteRenderer Seed;
	private Color semiVisible;
	private bool setOn;
	private bool setOff;
	private bool switchable = true;

	// Use this for initialization
	void Start()
	{
		//col = GetComponent<Collider2D>();
		spriteR = GetComponent<SpriteRenderer>();
		semiVisible = new Color(1, 1, 1, 0.5f);
		setOn = false;
		setOff = false;
	}

	// Update is called once per frame
	void Update()
	{
		isOn = SwitchController.instance.isOn;

		if (!switchable)
        {
			col1.enabled = false;
			col2.enabled = true;
			spriteR.sprite = OffSprite;
			Seed.enabled = true;
			//spriteR.color = semiVisible;
			setOff = true;
			setOn = false;
		}

		if (!setOn)
		{
			if (!isOn && switchable)
			{
				col1.enabled = true;
				col2.enabled = false;
				Seed.enabled = false;
				spriteR.sprite = OnSprite;
				spriteR.color = Color.white;
				setOn = true;
				setOff = false;
			}

		}
		if (!setOff)
		{
			if (isOn && switchable)
			{
				col1.enabled = false;
				col2.enabled = true;
				spriteR.sprite = OffSprite;
				Seed.enabled = true;
				//spriteR.color = semiVisible;
				setOff = true;
				setOn = false;
			}
		}
	}

	public void NotAbleToSwitch()
    {
		switchable = false;
    }

	public void AbleToSwitch()
	{
		switchable = true;
		isOn = false;
	}
}