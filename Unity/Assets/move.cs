using UnityEngine;
using System.Collections;
using System;

public class move : MonoBehaviour {
	float i = 0;
	float rate = 1000f;
	Vector3 startPos;
	Vector3 endPos; 
	float xcoord;
	float ycoord;
	float j = 0;
	

	// Use this for initialization
	void Start () {
	    startPos = transform.localPosition;
	}
	// Update is called once per frame
	void Update () {
		/*GameObject camera = GameObject.Find("Main Camera");
		StartClient startClient = camera.GetComponent<StartClient>();
		string coordinates = startClient.foo();
		Debug.Log("coordinates: " +coordinates);*/
		endPos = new Vector3(20,0,-850);
		//transform.LookAt(endPos);
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, rate * Time.deltaTime);
		/*xcoord = 0;
		ycoord = j;
	   endPos = new Vector3(xcoord,0,ycoord);
	   i += Time.deltaTime * rate;
       transform.localPosition = Vector3.Lerp(startPos, endPos, i);
		Debug.Log(transform.position)
		j = j + 10;*/
	}
}
