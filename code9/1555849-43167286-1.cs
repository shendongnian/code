    using System;
    using System.Net;
    using SimpleTCP;
    using System.Text;
    
    namespace client
    {
        class Program
        {
            static void Main(string[] args)
            {
                SimpleTcpClient client = new SimpleTcpClient(); //Instantiate the client
                client.StringEncoder = Encoding.UTF8; //Config
                client.DataReceived += Client_DataReceived; //Subscribe to the DataRecieved event.
                client.Connect("127.0.0.1", 6500); //Connect to the server
                while(true) //Keep the console open until you close it.
                {
                    //As long as the console is open, every message you type will be sent to the server.
                    client.WriteLineAndGetReply(Console.ReadLine(), TimeSpan.FromSeconds(5)); 
                }
            }
            static void Client_DataReceived(object sender, Message m)
            {
                Console.WriteLine(m.MessageString); //Write recieved reply from server to console.
            }
        }
    }
