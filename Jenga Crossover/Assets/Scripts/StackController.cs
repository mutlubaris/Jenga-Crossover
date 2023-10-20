using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Networking;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class StackController : MonoBehaviour
{
    [SerializeField] private BlockSpawner _sixthGradeBlockSpawner;
    [SerializeField] private BlockSpawner _seventhGradeBlockSpawner;
    [SerializeField] private BlockSpawner _eighthGradeBlockSpawner;

	private string _URL = "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";
	private int _firstIndex = 2;
	private int _lastIndex = 114;

	private void Start()
	{
		StartCoroutine(GetDatas());
	}

	private IEnumerator GetDatas()
	{
		using (UnityWebRequest request = UnityWebRequest.Get(_URL))
		{
			yield return request.SendWebRequest();

			if (request.result == UnityWebRequest.Result.ConnectionError)
				Debug.LogError(request.error);
			else
			{
				string json = request.downloadHandler.text;
				SimpleJSON.JSONNode stats = SimpleJSON.JSON.Parse(json);

				for (int i = _firstIndex; i < _lastIndex; i++)
				{
					if (String.Equals(stats[i]["grade"], "6th Grade"))
					{
						Block newBlock = _sixthGradeBlockSpawner.SpawnBlock();
						newBlock.subject = stats[i]["subject"];
						newBlock.grade = stats[i]["grade"];
						newBlock.mastery = stats[i]["mastery"];
						newBlock.domainid = stats[i]["domainid"];
						newBlock.domain = stats[i]["domain"];
						newBlock.cluster = stats[i]["cluster"];
						newBlock.standardid = stats[i]["standardid"];
						newBlock.standarddescription = stats[i]["standarddescription"];
					}
					else if (String.Equals(stats[i]["grade"], "7th Grade"))
					{
						Block newBlock = _seventhGradeBlockSpawner.SpawnBlock();
						newBlock.subject = stats[i]["subject"];
						newBlock.grade = stats[i]["grade"];
						newBlock.mastery = stats[i]["mastery"];
						newBlock.domainid = stats[i]["domainid"];
						newBlock.domain = stats[i]["domain"];
						newBlock.cluster = stats[i]["cluster"];
						newBlock.standardid = stats[i]["standardid"];
						newBlock.standarddescription = stats[i]["standarddescription"];
					}
					else if (String.Equals(stats[i]["grade"], "8th Grade"))
					{
						Block newBlock = _eighthGradeBlockSpawner.SpawnBlock();
						newBlock.subject = stats[i]["subject"];
						newBlock.grade = stats[i]["grade"];
						newBlock.mastery = stats[i]["mastery"];
						newBlock.domainid = stats[i]["domainid"];
						newBlock.domain = stats[i]["domain"];
						newBlock.cluster = stats[i]["cluster"];
						newBlock.standardid = stats[i]["standardid"];
						newBlock.standarddescription = stats[i]["standarddescription"];
					}
				}			
			}
		}
	}
}
