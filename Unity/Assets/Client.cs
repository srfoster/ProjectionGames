using UnityEngine;
using System.Collections;
using System;
using System.Net.Sockets;
using System.IO;


public class Client {
	
	public string message = "here";
	public string error = "";
	
	
	public void Start(){
			NetworkStream stream = null;
		TcpClient client = null;
		
			
  		try 
  		{
    		Int32 port = 2013;
			message = "in 1st try";
    		client = new TcpClient("127.0.0.1", port);

      		stream = client.GetStream();
			StreamReader input = new StreamReader(stream);

   			Byte[] data = new Byte[24];
		    // String to store the response ASCII representation.
		    String responseData = String.Empty;

			while(true){
				try{
					message = "above read line";
				    message = input.ReadLine();
					message = "below read line";
					
				}catch(Exception e){
					error = e.Message;	
					message = "error";
				}
			}
	  } 
	  catch (ArgumentNullException e) 
	  {
	    Debug.Log("ArugmentNullException");
	  } 
	  catch (SocketException e) 
	  {
	    Debug.Log("SocketException");
	  }
	
			
		// Close everything.
		stream.Close();         
		client.Close(); 	
	}
}
