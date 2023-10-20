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

	private void Start()
	{
		rigid = GetComponent<Rigidbody>();
	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(1)) 
		{
			print(cluster);
		}
	}
}
