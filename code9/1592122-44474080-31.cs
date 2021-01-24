    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    namespace ConcoxServer
    {
        public class StateObject
        {
            public long connectionNumber = -1;
            public Socket workSocket { get; set; }
            public byte[] buffer { get; set; }
        }
        public enum PROTOCOL_NUMBER
        {
            LOGIN_MESSAGE = 0x01,
            LOCATION_DATA = 0x12,
            STATUS_INFO = 0X13,
            STRING_INFO = 0X15,
            ALARM_DATA = 0X16,
            GPS_QUERY_ADDR_PHONE_NUM = 0X1A,
            COMMAND_INFO = 0X80
        }
        public enum UNPACK_STATUS
        {
            ERROR,
            NOT_ENOUGH_BYTES,
            GOOD_MESSAGE,
            DEFAULT
        }
        public enum PROCESS_STATE
        {
            ACCEPT,
            READ,
            PROCESS,
            UNPACK
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
            static byte[] loginResponse = { 0x78, 0x78, 0x05, 0x01, 0x00, 0x00, 0x00, 0x00, 0x0D, 0x0A };
            static byte[] alarmResponse = { 0x78, 0x78, 0x00, 0x97, 0x7E, 
                                              0x00, 0x00, 0x00, 0x01,
                                              0x41, 0x4C, 0x41, 0x52, 0x4D, 0x53, 0x4D, 0x53,   //ALARMS
                                              0x26, 0x26,                                       //&&
                                              0x80, 0x00, 0x72, 0x00, 0x79, 0x00, 0x78, 0x00,   // PHONE HOME
                                              0x69, 0x00, 0x32, 0x00, 0x72, 0x00, 0x79, 0x00,
                                              0x77, 0x00, 0x69,
                                              0x26, 0x26,                                       //&&
                                              0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,   // Phone Numbe
                                              0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                              0x00, 0x00, 0x00, 0x00, 0x00,
                                              0x23, 0x23,                                       //##
                                              0x00, 0x00,                                       //serial number
                                              0x00, 0x00,                                       //check bytes
                                              0x0D, 0x0A                                        //stop bytes
                                          };
            static long connectionNumber = 0;
            //mapping of connection number to StateObject
            static Dictionary<long, KeyValuePair<List<byte>, StateObject>> connectionDict = new Dictionary<long, KeyValuePair<List<byte>, StateObject>>();
            //fifo contains list of connections number wait with receive data
            public static List<long> fifo = new List<long>();
            public static AutoResetEvent allDone = new AutoResetEvent(false);
            public void StartListening(string IP, int port, Boolean test)
            {
                // Establish the local endpoint for the socket.
                // The DNS name of the computer
                // running the listener is "host.contoso.com".
                IPHostEntry ipHostInfo = Dns.GetHostEntry(IP);  //Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                //IPAddress local = IPAddress.Parse(IP);
                UInt16 sendCRC = 0;
                DateTime date;
                int year = 0;
                int month = 0;
                int day = 0;
                int hour = 0;
                int minute = 0;
                int second = 0;
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
                    Boolean firstMessage = true;
                    //loop forever
                    while (true)
                    {
                        allDone.WaitOne();
                        //read fifo until empty
                        while (fifo.Count > 0)
                        {
                            //read one connection until buffer doesn't contain any more packets
                            KeyValuePair<List<byte>, StateObject> byteState = ReadWrite(-1, PROCESS_STATE.PROCESS, null, null, null);
                            StateObject state = byteState.Value;
                            while (true)
                            {
                                KeyValuePair<UNPACK_STATUS, byte[]> status = Unpack(byteState.Key);
                                if (status.Key == UNPACK_STATUS.NOT_ENOUGH_BYTES) break;
                                //message is 2 start bytes + 1 byte (message length) + 1 byte message length + 2 end bytes
                                byte[] receiveMessage = status.Value;
                                if (status.Key != UNPACK_STATUS.GOOD_MESSAGE)
                                { int zzz = -1; }
                                int messageLength = receiveMessage[2];
                                Console.WriteLine("Status : '{0}', Receive Message : '{1}'", status.Key == UNPACK_STATUS.GOOD_MESSAGE ? "Good" : "Bad", BytesToString(receiveMessage.Take(messageLength + 5).ToArray()));
                                if (status.Key != UNPACK_STATUS.GOOD_MESSAGE)
                                {
                                    Console.WriteLine("Error : Bad Login Message, Data : '{0}'", BytesToString(receiveMessage));
                                    break;
                                }
                                else
                                {
                                    if (firstMessage)
                                    {
                                        if (receiveMessage[3] != 0x01)
                                        {
                                            Console.WriteLine("Error : Expected Login Message : '{0}'", BytesToString(receiveMessage));
                                            break;
                                        }
                                        firstMessage = false;
                                    }
                                    //skip start bytes, message length.  then go back 4 bytes (CRC and serial number)
                                    byte[] serialNumber = receiveMessage.Skip(2 + 1 + messageLength - 4).Take(2).ToArray();
                                    PROTOCOL_NUMBER protocolNumber = (PROTOCOL_NUMBER)receiveMessage[3];
                                    switch (protocolNumber)
                                    {
                                        case PROTOCOL_NUMBER.LOGIN_MESSAGE:
                                            serialNumber.CopyTo(loginResponse, 4);
                                            sendCRC = crc_bytes(loginResponse.Skip(2).Take(loginResponse.Length - 6).ToArray());
                                            loginResponse[loginResponse.Length - 4] = (byte)((sendCRC >> 8) & 0xFF);
                                            loginResponse[loginResponse.Length - 3] = (byte)((sendCRC) & 0xFF);
                                            string terminalID = Encoding.ASCII.GetString(receiveMessage.Skip(4).Take(messageLength - 5).ToArray());
                                            Console.WriteLine("Received good login message from Serial Number : '{0}', Terminal ID = '{1}'", "0x" + serialNumber[0].ToString("X2") + serialNumber[1].ToString("X2"), terminalID);
                                            Console.WriteLine("Send Message : '{0}'", BytesToString(loginResponse));
                                            Send(state.workSocket, loginResponse);
                                            break;
                                        case PROTOCOL_NUMBER.LOCATION_DATA:
                                            year = receiveMessage[4];
                                            month = receiveMessage[5];
                                            day = receiveMessage[6];
                                            hour = receiveMessage[7];
                                            minute = receiveMessage[8];
                                            second = receiveMessage[9];
                                            date = new DateTime(2000 + year, month, day, hour, minute, second);
                                            Console.WriteLine("Received good location message from Serial Number '{0}', Time = '{1}'", "0x" + serialNumber[0].ToString("X2") + serialNumber[1].ToString("X2"), date.ToLongDateString());
                                            break;
                                        case PROTOCOL_NUMBER.ALARM_DATA:
                                            year = receiveMessage[4];
                                            month = receiveMessage[5];
                                            day = receiveMessage[6];
                                            hour = receiveMessage[7];
                                            minute = receiveMessage[8];
                                            second = receiveMessage[9];
                                            date = new DateTime(2000 + year, month, day, hour, minute, second);
                                            Console.WriteLine("Received good alarm message from Serial Number '{0}', Time = '{1}'", "0x" + serialNumber[0].ToString("X2") + serialNumber[1].ToString("X2"), date.ToLongDateString());
                                            int packetLen = alarmResponse.Length - 5;
                                            alarmResponse[2] = (byte)(packetLen & 0xFF);
                                            serialNumber.CopyTo(alarmResponse, packetLen - 1);
                                            sendCRC = crc_bytes(alarmResponse.Skip(2).Take(packetLen - 1).ToArray());
                                            alarmResponse[packetLen + 1] = (byte)((sendCRC >> 8) & 0xFF);
                                            alarmResponse[packetLen + 2] = (byte)((sendCRC) & 0xFF);
                                            Console.WriteLine("Send Message : '{0}'", BytesToString(alarmResponse));
                                            Send(state.workSocket, alarmResponse);
                                            break;
                                    } //end switch
                                }// End if
                            } //end while
                        }//end while fifo > 0
                        allDone.Reset();
                    }//end while true
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
            static KeyValuePair<UNPACK_STATUS, byte[]> Unpack(List<byte> working_buffer)
            {
                //return null indicates an error
                if (working_buffer.Count() < 3) return new KeyValuePair<UNPACK_STATUS, byte[]>(UNPACK_STATUS.NOT_ENOUGH_BYTES, null);
                int len = working_buffer[2];
                if (working_buffer.Count < len + 5) return new KeyValuePair<UNPACK_STATUS, byte[]>(UNPACK_STATUS.NOT_ENOUGH_BYTES, null);
                // check start and end bytes
                KeyValuePair<List<byte>, StateObject> byteState = ReadWrite(-1, PROCESS_STATE.UNPACK, null, null, working_buffer);
                if (byteState.Key.Count == 0) return new KeyValuePair<UNPACK_STATUS, byte[]>(UNPACK_STATUS.ERROR, null);
                List<byte> packet = byteState.Key;
                //crc test
                byte[] crc = packet.Skip(len + 1).Take(2).ToArray();
                ushort crcShort = (ushort)((crc[0] << 8) | crc[1]);
                //skip start bytes, crc, and end bytes
                ushort CalculatedCRC = crc_bytes(packet.Skip(2).Take(len - 1).ToArray());
                if (CalculatedCRC != crcShort)
                {
                    return new KeyValuePair<UNPACK_STATUS, byte[]>(UNPACK_STATUS.ERROR, null);
                }
                return new KeyValuePair<UNPACK_STATUS, byte[]>(UNPACK_STATUS.GOOD_MESSAGE, packet.ToArray());
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
            static KeyValuePair<List<byte>, StateObject> ReadWrite(long connectionNumber, PROCESS_STATE ps, Socket handler, IAsyncResult ar, List<byte> working_buffer)
            {
                KeyValuePair<List<byte>, StateObject> byteState = new KeyValuePair<List<byte>, StateObject>(); ;
                StateObject state = null;
                Object thisLock = new Object();
                lock (thisLock)
                {
                    switch (ps)
                    {
                        case PROCESS_STATE.ACCEPT:
                            state = new StateObject();
                            state.buffer = new byte[BUFFER_SIZE];
                            state.connectionNumber = connectionNumber;
                            connectionDict.Add(connectionNumber++, new KeyValuePair<List<byte>, StateObject>(new List<byte>(), state));
                            // Create the state object.  
                            state.workSocket = handler;
                            byteState = new KeyValuePair<List<byte>, StateObject>(null, state);
                            break;
                        case PROCESS_STATE.READ:
                            //catch when client disconnects
                            try
                            {
                                // Read data from the client socket. 
                                int bytesReads = handler.EndReceive(ar);
                                if (bytesReads > 0)
                                {
                                    byteState = connectionDict[connectionNumber];
                                    byteState.Key.AddRange(byteState.Value.buffer.Take(bytesReads).ToArray());
                                }
                                //only put one instance of connection number into fifo
                                if (!fifo.Contains(connectionNumber))
                                {
                                    fifo.Add(connectionNumber);
                                }
                            }
                            catch (Exception ex)
                            {
                                fifo.RemoveAll(x => x == connectionNumber);
                                connectionDict.Remove(connectionNumber);
                                byteState = new KeyValuePair<List<byte>, StateObject>();
                            }
                            break;
                        case PROCESS_STATE.PROCESS:
                            if (fifo.Count > 0)
                            {
                                byteState = connectionDict[fifo.First()];
                                fifo.RemoveAt(0);
                                byteState.Key.AddRange(byteState.Key);
                            }
                            break;
                        case PROCESS_STATE.UNPACK:
                            int len = working_buffer[2];
                            if ((working_buffer[0] != 0x78) && (working_buffer[1] != 0x78) && (working_buffer[len + 3] != 0x0D) && (working_buffer[len + 4] != 0x0A))
                            {
                                working_buffer.Clear();
                                return new KeyValuePair<List<byte>, StateObject>(null, null);
                            }
                            List<byte> packet = working_buffer.Take(len + 5).ToList();
                            working_buffer.RemoveRange(0, len + 5);
                            byteState = new KeyValuePair<List<byte>, StateObject>(packet, null);
                            break;
                    }// end switch
                }
                return byteState;
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
            public static void AcceptCallback(IAsyncResult ar)
            {
                try
                {
                    // Get the socket that handles the client request.  
                    Socket listener = (Socket)ar.AsyncState;
                    Socket handler = listener.EndAccept(ar);
                    StateObject state = ReadWrite(0, PROCESS_STATE.ACCEPT, handler, ar, null).Value;
                    handler.BeginReceive(state.buffer, 0, BUFFER_SIZE, 0,
                        new AsyncCallback(ReadCallback), state);
                }
                catch (Exception ex)
                {
                }
            }
            public static void ReadCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the state object and the handler socket
                    // from the asynchronous state object.
                    StateObject state = ar.AsyncState as StateObject;
                    Socket handler = state.workSocket;
                    // Read data from the client socket. 
                    KeyValuePair<List<byte>, StateObject> byteState = ReadWrite(state.connectionNumber, PROCESS_STATE.READ, handler, ar, null);
                    if (byteState.Value != null)
                    {
                        handler.BeginReceive(state.buffer, 0, BUFFER_SIZE, 0,
                            new AsyncCallback(ReadCallback), state);
                    }
                }
                catch (Exception ex)
                {
                }
                // Signal the main thread to continue.  
                allDone.Set();
            }
        }
    }
