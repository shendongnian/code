    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Collections;
    using System.IO;
    //using System.Diagnostics;
    
    public class SynchronousSocketListener
    {
    	// Incoming data from the client.
    	public static string data = null;
    
    	public static void StartListening()
    	{
    		// Data buffer for incoming data.
    		byte[] bytes = new Byte[1024];
    
    		// Establish the local endpoint for the socket.
    		// Dns.GetHostName returns the name of the 
    		// host running the application.
    		IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
    		IPAddress ipAddress = ipHostInfo.AddressList[0];
    		IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
    
    		// Create a TCP/IP socket.
    		Socket listener = new Socket(AddressFamily.InterNetwork,
    			SocketType.Stream, ProtocolType.Tcp);
    
    		// Bind the socket to the local endpoint and 
    		// listen for incoming connections.
    		while (true)
    		{
    
    
    			try
    			{
    				//if (!listener.IsBound)
    				//{
    					listener.Bind(localEndPoint);
    				//}
    				listener.Listen(10);
    
    				byte[] msg = null;
    				// Start listening for connections.
    				while (true)
    				{
    					Console.WriteLine("Waiting for a connection...");
    					// Program is suspended while waiting for an incoming connection.
    					Socket handler = listener.Accept();
    					while (true)
    					{
    
    
    						data = null;
    
    						// An incoming connection needs to be processed.
    						bytes = new byte[1024];
    						int bytesRec = handler.Receive(bytes);
    						data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
    
    						if (data.Equals("ping"))
    						{
    							// Show the data on the console.                        
    							Console.WriteLine("Text received : {0}", data);
    
    							// Echo the data back to the client.
    							msg = Encoding.ASCII.GetBytes("pong");
    							handler.Send(msg);
    							//break;
    						}
    						if (data.Equals("dir"))
    						{
    							// Show the data on the console.                        
    							Console.WriteLine("Text received : {0}", data);
    
    							// Echo the data back to the client.
    							msg = Encoding.ASCII.GetBytes(System.AppDomain.CurrentDomain.BaseDirectory);
    							handler.Send(msg);
    							//break;
    						}
    
    						if (data.Equals("files"))
    						{
    							// Show the data on the console.                        
    							Console.WriteLine("Text received : {0}", data);
    
    							String files = "";
    
    							string[] fileEntries = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory);
    							foreach (string fileName in fileEntries)
    								files += ProcessFile(fileName);
    
    							// Echo the data back to the client.
    							msg = Encoding.ASCII.GetBytes(files);
    							handler.Send(msg);
    							//break;
    
    						}
    					}
    
    					// Show the data on the console.
    					//Console.WriteLine("Text received : {0}", data);
    
    					// Echo the data back to the client.
    					//byte[] msg = Encoding.ASCII.GetBytes(data);
    
    					//handler.Send(msg);
    					//handler.Shutdown(SocketShutdown.Both);
    					//handler.Close();
    				}
    
    			}
    
    			catch (Exception e)
    			{
    				Console.WriteLine(e.ToString());
    			}
    		}
    		Console.WriteLine("\nPress ENTER to continue...");
    		Console.Read();
    
    	}
    
    	public static String ProcessFile(string path)
    	{
    		return path += "\n\n" + path;
    	}
    
    	public static void ProcessDirectory(string targetDirectory)
    	{
    		// Process the list of files found in the directory.
    		string[] fileEntries = Directory.GetFiles(targetDirectory);
    		foreach (string fileName in fileEntries)
    			ProcessFile(fileName);
    
    		// Recurse into subdirectories of this directory.
    		string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
    		foreach (string subdirectory in subdirectoryEntries)
    			ProcessDirectory(subdirectory);
    	}
    
    	public static int Main(String[] args)
    	{
    		StartListening();
    		return 0;
    	}
    }
