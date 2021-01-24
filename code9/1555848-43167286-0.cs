    using System;
    using System.Net;
    using SimpleTCP;
    using System.Text;
    
    namespace server
    {
        class Program
        {
            static void Main(string[] args)
            {
                SimpleTcpServer server = new SimpleTcpServer(); //Instantiate server.
                server.Delimiter = 0x13; //Config
                server.StringEncoder = Encoding.UTF8; //Config
                server.DataReceived += Server_DataReceived; //Subscribe to DataRecieved event.
                IPAddress ip = IPAddress.Parse("127.0.0.1"); //IP Address using .Parse()
                int port = 6500; //Port number
                server.Start(ip, port); //Start listening to incoming connections and data.
                Console.ReadKey(); //Pause the console.
            }
    
            static void Server_DataReceived(object sender, SimpleTCP.Message m)
            {
                Console.WriteLine(m.MessageString); //Write message to console.
                string replyMessage = String.Format("You said {0}", m.MessageString); //This is the reply message
                m.ReplyLine(replyMessage); //Send reply message back to client.
            }
        }
    }
