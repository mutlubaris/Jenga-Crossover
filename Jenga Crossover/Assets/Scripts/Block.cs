using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public string subject;
	public string grade;
	public string mastery;
	public string domainid;
	public string domain;
	public string cluster;
	public string standardid;
	public string standarddescription;
	public Rigidbody rigid;
	public Outline outline;

	private void Start()
	{
		rigid = GetComponent<Rigidbody>();
	}

	private void OnEnable()
	{
		EventManager.OnBlockRightClicked.AddListener(DisableOutline);
	}

	private void OnDisable()
	{
		EventManager.OnBlockRightClicked.RemoveListener(DisableOutline);
	}

	private void DisableOutline(Block arg0)
	{
		outline.enabled = false;
	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(1)) 
		{
			EventManager.OnBlockRightClicked.Invoke(this);
			outline.enabled = true;
		}
	}
}
