    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    namespace ConsoleApplication1
    {
        public class StateObject
        {
            public static Socket workSocket { get; set; }
            public byte[] buffer { get; set; }
            public static Boolean status = false;
            public static List<List<byte>> history = new List<List<byte>>();
        }
        class Program
        {
            const string IP = "127.0.0.1";
            const int PORT = 8841;
            const Boolean test = true;
            static void Main(string[] args)
            {
                GPS gps = new GPS();
                gps.StartListening(IP, PORT, test);
                Console.WriteLine("Connection Ended");
            }
        }
        public class GPS
        {
            const int BUFFER_SIZE = 1024;
            static byte[] response = { 0x78, 0x78, 0x05, 0x01, 0x00, 0x00, 0x00, 0x00, 0x0D, 0x0A };
            static List<StateObject> connections = new List<StateObject>();
            public static AutoResetEvent allDone = new AutoResetEvent(false);
            public void StartListening(string IP, int port, Boolean test)
            {
                // Establish the local endpoint for the socket.
                // The DNS name of the computer
                // running the listener is "host.contoso.com".
                IPHostEntry ipHostInfo = Dns.GetHostEntry(IP);  //Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPAddress local = IPAddress.Parse(IP);
                IPEndPoint localEndPoint = null;
                if (test)
                {
                    localEndPoint = new IPEndPoint(IPAddress.Any, port);
                }
                else
                {
                    localEndPoint = new IPEndPoint(ipAddress, port);
                }
                // Create a TCP/IP socket.
                Socket listener = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                // Bind the socket to the local endpoint and listen for incoming connections.
                try
                {
                    allDone.Reset();
                    listener.Bind(localEndPoint);
                    listener.Listen(100);
                    //login code, wait for 1st message
                    Console.WriteLine("Wait 5 seconds for login message");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                    if (StateObject.status == false)
                    {
                        Console.WriteLine("Error : Bad Login Message, Data : '{0}'", BytesToString(StateObject.history.Last().ToArray()));
                    }
                    else
                    {
                        byte[] loginMessage = StateObject.history.Last().ToArray();
                        if (loginMessage[3] != 0x01)
                        {
                            Console.WriteLine("Error : Expected Login Message : '{0}'", BytesToString(StateObject.history.Last().ToArray()));
                        }
                        else
                        {
                            int messageLength = loginMessage[2];
                            //skip start bytes, message length.  then go back 4 bytes (CRC and serial number)
                            byte[] serialNumber = loginMessage.Skip(2 + 1 + messageLength - 4).Take(2).ToArray();
                            serialNumber.CopyTo(response, 4);
                            UInt16 sendCRC = crc_bytes(response.Take(response.Length - 2).ToArray());
                            response[response.Length - 4] = (byte)((sendCRC >> 8) & 0xFF);
                            response[response.Length - 3] = (byte)((sendCRC) & 0xFF);
                            Console.WriteLine("Received good login message from Serial Number : '{0}'", "0x" + serialNumber[0].ToString("X2") + serialNumber[1].ToString("X2"));
                            Console.WriteLine("Send Message : '{0}'", BytesToString(response));
                            Send(StateObject.workSocket, response);
                            allDone.Reset();
                            //receive gps locations
                            while (true)
                            {
                                allDone.WaitOne();
                                Console.WriteLine("Status : '{0}', Receive Message : '{0}'", StateObject.status ? "Good" : "Bad", BytesToString(StateObject.history.Last().ToArray()));
                                allDone.Reset();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            static string BytesToString(byte[] bytes)
            {
                return string.Join("", bytes.Select(x => x.ToString("X2")));
            }
            static void Send(Socket handler, String data)
            {
                // Convert the string data to byte data using ASCII encoding.
                byte[] byteData = Encoding.ASCII.GetBytes(data);
                // Begin sending the data to the remote device.
                handler.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), handler);
            }
            static void Send(Socket socket, byte[] data)
            {
                // Convert the string data to byte data using ASCII encoding.
                // byte[] byteData = Encoding.ASCII.GetBytes(data);
                // Begin sending the data to the remote device.
                socket.BeginSend(data, 0, data.Length, 0,
                    new AsyncCallback(SendCallback), socket);
            }
            static void SendCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.
                    Socket handler = ar.AsyncState as Socket;
                    // Complete sending the data to the remote device.
                    int bytesSent = handler.EndSend(ar);
                    // Console.WriteLine("Sent {0} bytes to client.", bytesSent);
                }
                catch (Exception e)
                {
                    // Console.WriteLine(e.ToString());
                }
            }
            static byte[] Unpack(byte[] data, int length)
            {
                //return null indicates an error
                // check start and end bytes
                if ((data[0] != 0x78) && (data[1] != 0x78) && (data[length - 2] != 0x0D) && (data[length - 1] == 0x01))
                {
                    return null;
                }
                //crc test
                byte[] packet = data.Take(length - 2).ToArray();
                byte[] crc = data.Skip(length - 4).Take(2).ToArray();
                ushort crcShort = (ushort)((crc[0] << 8) | crc[1]);
                //skip start bytes, crc, and end bytes
                ushort CalculatedCRC = crc_bytes(packet.Skip(2).Take(length - 6).ToArray());
                if (CalculatedCRC != crcShort)
                {
                    return null;
                }
                return packet;
            }
            static public UInt16 crc_bytes(byte[] data)
            {
                ushort crc = 0xFFFF;
                for (int i = 0; i < data.Length; i++)
                {
                    crc ^= (ushort)(Reflect(data[i], 8) << 8);
                    for (int j = 0; j < 8; j++)
                    {
                        if ((crc & 0x8000) > 0)
                            crc = (ushort)((crc << 1) ^ 0x1021);
                        else
                            crc <<= 1;
                    }
                }
                crc = Reflect(crc, 16);
                crc = (ushort)~crc;
                return crc;
            }
            static public ushort Reflect(ushort data, int size)
            {
                ushort output = 0;
                for (int i = 0; i < size; i++)
                {
                    int lsb = data & 0x01;
                    output = (ushort)((output << 1) | lsb);
                    data >>= 1;
                }
                return output;
            }
            public static void AcceptCallback(IAsyncResult ar)
            {
                // Get the socket that handles the client request.  
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);
                StateObject state = new StateObject();
                state.buffer = new byte[BUFFER_SIZE];
                connections.Add(state);
                // Create the state object.  
                StateObject.workSocket = handler;
                handler.BeginReceive(state.buffer, 0, BUFFER_SIZE, 0,
                    new AsyncCallback(ReadCallback), state);
            }
            public static void ReadCallback(IAsyncResult ar)
            {
                String content = String.Empty;
                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = ar.AsyncState as StateObject;
                Socket handler = StateObject.workSocket;
                // Read data from the client socket. 
                int bytesReads = handler.EndReceive(ar);
                if (bytesReads > 0)
                {
                    byte[] bytes = Unpack(state.buffer, bytesReads);
                    if (bytes == null)
                    {
                        StateObject.status = false;
                    }
                    else
                    {
                        StateObject.status = true;
                    }
                    StateObject.history.Add(state.buffer.ToList());
                }
                handler.BeginReceive(state.buffer, 0, BUFFER_SIZE, 0,
                    new AsyncCallback(ReadCallback), state);
                // Signal the main thread to continue.  
                allDone.Set();
            }
        }
    }
