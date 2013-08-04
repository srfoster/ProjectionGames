using UnityEngine;
using System.Collections;
using System.Threading;

public class StartClient : MonoBehaviour {
	
	Client client = null;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Starting StartClient");
		
		Thread client_thread = new Thread(new ThreadStart(StartTheClient));
		client_thread.Start();
		
		Debug.Log("Thread Started");
	}
	
	/*public string foo() {
		client = new Client();
		return client.message;	
	}*/
	void StartTheClient(){
		Debug.Log("Starting Client");
	    client = new Client();
		Debug.Log("Client Started");
		client.Start();
	}
	
	void Update(){
		if(client != null){
			Debug.Log(client.message);
		} else {
			Debug.Log("not connected");
		}
	}
	
	/*void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,300,100), client.message);

	}*/
	
}
