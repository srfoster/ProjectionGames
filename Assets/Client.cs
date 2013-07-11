using UnityEngine;
using System.Collections;
using System;
using System.Net.Sockets;
using System.IO;


public class Client {
	
	public string message = "";
	public string error = "";
	
	public Client() 
	{

	}
	
	
	public void Start(){
			NetworkStream stream = null;
		TcpClient client = null;
		
			
  		try 
  		{
 
    		Int32 port = 2013;
			
    		client = new TcpClient("192.168.0.5", port);

      		stream = client.GetStream();
			StreamReader input = new StreamReader(stream);

   			Byte[] data = new Byte[23];

		    // String to store the response ASCII representation.
		    String responseData = String.Empty;
			
			while(true){
				
				try{
				    message = input.ReadLine();
				}catch(Exception e){
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