using UnityEngine;
using System.Collections;
using System;
using System.Net.Sockets;
using System.IO;


public class Client {
	
	public string message = "I'm not changing";
	public string error = "";
	
	
	public void Start(){
			NetworkStream stream = null;
		TcpClient client = null;
		
			
  		try 
  		{
            message = "I'm thinking about changing for you";
    		Int32 port = 2013;
			
    		client = new TcpClient("127.0.0.1", port);

      		stream = client.GetStream();
			StreamReader input = new StreamReader(stream);

   			Byte[] data = new Byte[23];
		    // String to store the response ASCII representation.
		    String responseData = String.Empty;

			while(true){
				try{
				    message = input.Read() + " for you I changed" + Environment.NewLine;
					
				}catch(Exception e){
					message = "I lied. I'm a jerk!";
					error = e.Message;	
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
