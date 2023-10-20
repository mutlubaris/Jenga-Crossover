using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIFetcher : MonoBehaviour
{
    private string URL = "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";

    public string subject;
    public string grade;
    public string mastery;
    public string domainid;
    public string domain;
    public string cluster;
    public string standardid;
    public string standarddescription;

    public int index = 2;

	private void Start()
	{
        StartCoroutine(GetDatas());
	}

	private IEnumerator GetDatas()
    {
        using(UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
                Debug.LogError(request.error);
            else
            {
                string json = request.downloadHandler.text;
                SimpleJSON.JSONNode stats = SimpleJSON.JSON.Parse(json);

                subject = stats[index]["subject"];
				grade = stats[index]["grade"];
				mastery = stats[index]["mastery"];
				domainid = stats[index]["domainid"];
				domain = stats[index]["domain"];
				cluster = stats[index]["cluster"];
				standardid = stats[index]["standardid"];
				standarddescription = stats[index]["standarddescription"];
			}
        }
    }
}
