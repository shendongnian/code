    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Data;
    using System.Data.SqlClient;
    using System.ComponentModel;
    using System.Timers;
    namespace ConcoxServer
    {
        public class StateObject
        {
            public long connectionNumber = -1;
            public Socket workSocket { get; set; }
            public byte[] buffer { get; set; }
            public int fifoCount { get; set;}
            public string IMEI { get; set; }
        }
        public enum PROTOCOL_NUMBER
        {
            LOGIN_MESSAGE = 0x01,
            LOCATION_DATA = 0x12,
            STATUS_INFO = 0X13,
            STRING_INFO = 0X15,
            ALARM_DATA = 0X16,
            GPS_QUERY_ADDR_PHONE_NUM = 0X1A,
            COMMAND_INFO = 0X80,
            NONE
        }
        public enum UNPACK_STATUS
        {
            ERROR,
            NOT_ENOUGH_BYTES,
            BAD_CRC,
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
        public enum ALARM : Byte
        {
            NORMAL = 0,
            SHOCK_ALARM = 1,
            POWER_CUT_ALARM = 2,
            LOW_BATTERY = 3,
            SOS = 4
        }
        class Program
        {
            const string IP = "127.0.0.1";
            const int PORT = 8841;
            const Boolean test = true;
            static void Main(string[] args)
            {
                GPS gps = new GPS(IP, PORT, test);
                Console.WriteLine("Connection Ended");
            }
        }
        public class GPS
        {
            const int BUFFER_SIZE = 1024;
            const string CONNECT_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=GPSTracker;Integrated Security=SSPI;";
            const string LOGIN_INSERT_COMMMAND_TEXT = "use GPSTracker INSERT INTO Login (TerminalID,Date) VALUES(@TerminalID,@Date)";
            const string LOCATION_INSERT_COMMMAND_TEXT = "INSERT INTO T_Tracking (IMEI,TrackTime, CurrTime, Longitude, Lattitude,speed)" +
                "VALUES (@IMEI, @TrackTime, @CurrTime, @Longitude, @Lattitude, @speed)";
            static SqlConnection conn = null;
            static SqlCommand cmdLogin = null;
            static SqlCommand cmdLocation = null;
            static byte[] loginResponse = { 0x78, 0x78, 0x05, 0x01, 0x00, 0x00, 0x00, 0x00, 0x0D, 0x0A };
            static byte[] alarmResponse = { 0x78, 0x78, 0x05, 0x16, 0x00, 0x00, 0x00, 0x00, 0x0D, 0x0A };
            static byte[] alarmDataAddressResponse = { 0x78, 0x78, 0x00, 0x97, 0x7E,
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
            static byte[] heartbeatResponse = { 0x78, 0x78, 0x05, 0x13, 0x00, 0x00, 0x00, 0x00, 0x0D, 0x0A };
            static byte[] connectOilAndEletricity = {
                                              0x78, 0x78, 0x16, 0x80, 0x10, 0x12, 0x34, 0x56, 0x78, 0x48,  //server flag bit 0x12345678
                                              0x46, 0x59, 0x44, 0x2C, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30,
                                              0x23, 0x00, 0x00, 0x00, 0x00, 0x0D, 0x0A
                                         }; 
            static long connectionNumber = 0;
            //mapping of connection number to StateObject
            static Dictionary<long, KeyValuePair<List<byte>, StateObject>> connectionDict = new Dictionary<long, KeyValuePair<List<byte>, StateObject>>();
            //fifo contains list of connections number wait with receive data
            public static List<long> fifo = new List<long>();
            public static AutoResetEvent allDone = new AutoResetEvent(false);
            public static AutoResetEvent acceptDone = new AutoResetEvent(false);
            public GPS(string IP, int port, Boolean test)
            {
                try
                {
                    conn = new SqlConnection(CONNECT_STRING);
                    conn.Open();
                    cmdLogin = new SqlCommand(LOGIN_INSERT_COMMMAND_TEXT, conn);
                    cmdLogin.Parameters.Add("@TerminalID", SqlDbType.NVarChar, 8);
                    cmdLogin.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmdLocation = new SqlCommand(LOCATION_INSERT_COMMMAND_TEXT, conn);
                    cmdLocation.Parameters.Add("@IMEI", SqlDbType.NVarChar, 50);
                    cmdLocation.Parameters.Add("@TrackTime", SqlDbType.DateTime);
                    cmdLocation.Parameters.Add("@currTime", SqlDbType.DateTime);
                    cmdLocation.Parameters.Add("@Longitude", SqlDbType.NChar, 50);
                    cmdLocation.Parameters.Add("@Lattitude", SqlDbType.NVarChar, 50);
                    cmdLocation.Parameters.Add("@speed", SqlDbType.Float);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error : '{0}'", ex.Message);
                    //Console.ReadLine();
                    return;
                }
                try
                {
                    //initialize the timer for writing to database.
                    WriteDBAsync.WriteDatabase();
                    StartListening(IP, port, test);
                    // Open 2nd listener to simulate two devices, Only for testing
                    //StartListening(IP, port + 1, test);
                    ProcessMessages();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error : '{0}'", ex.Message);
                    //Console.ReadLine();
                    return;
                }
            }
            public enum DATABASE_MESSAGE_TYPE
            {
                LOGIN,
                LOCATION
            }
            public class WriteDBMessage
            {
                public DATABASE_MESSAGE_TYPE message { get; set; }
            }
            public class WriteDBMessageLogin : WriteDBMessage
            {
                public DateTime date { get; set; }
                public string IMEI { get; set; }
            }
            public class WriteDBMessageLocation : WriteDBMessage 
            {
                public string IMEI { get; set; }
                public DateTime trackTime { get; set; }
                public DateTime currTime { get; set; }
                public byte[] longitude { get; set; }
                public byte[] lattitude { get; set; }
                public float speed { get; set; }
                public byte[] courseStatus { get; set; }
            }
            public static class WriteDBAsync
            {
                public enum Mode
                {
                    READ,
                    WRITE
                }
                public static List<WriteDBMessage> fifo = new List<WriteDBMessage>();
                public static System.Timers.Timer timer = null;
                public static void WriteDatabase()
                {
                    timer = new System.Timers.Timer(1000);
                    timer.Elapsed += Timer_Elapsed;
                    timer.Start();
                }
                public static WriteDBMessage ReadWriteFifo(Mode mode, WriteDBMessage message)
                {
                    Object thisLock2 = new Object();
                    lock (thisLock2)
                    {
                        switch (mode)
                        {
                            case Mode.READ:
                                if(fifo.Count > 0)
                                {
                                    message = fifo[0];
                                    fifo.RemoveAt(0);
                                }
                                break;
                            case Mode.WRITE:
                                fifo.Add(message);
                                break;
                        }
                    }
                    return message;
                }
                static void Timer_Elapsed(object sender, ElapsedEventArgs e)
                {
                    timer.Enabled = false;
                    WriteDBMessage row = null;
                    int rowsAdded = 0;
                    uint number = 0;
                    double lat = 0;
                    string latStr = "";
                    double lon = 0;
                    string longStr = "";
                    int degrees = 0;
                    double minutes = 0;
                    try
                    {
                        while((row = ReadWriteFifo(Mode.READ, null)) != null)
                        {
                            switch(row.message)
                            {
                                case DATABASE_MESSAGE_TYPE.LOGIN:
                                    cmdLogin.Parameters["@TerminalID"].Value = ((WriteDBMessageLogin)row).IMEI;
                                    cmdLogin.Parameters["@Date"].Value = ((WriteDBMessageLogin)row).date;
                                    rowsAdded = cmdLogin.ExecuteNonQuery();
                                    break;
                                case DATABASE_MESSAGE_TYPE.LOCATION:
                                    cmdLocation.Parameters["@IMEI"].Value = ((WriteDBMessageLocation)row).IMEI;
                                    cmdLocation.Parameters["@TrackTime"].Value = ((WriteDBMessageLocation)row).trackTime;
                                    cmdLocation.Parameters["@currTime"].Value = ((WriteDBMessageLocation)row).currTime;
                                    number = BitConverter.ToUInt32(((WriteDBMessageLocation)row).longitude.Reverse().ToArray(), 0);
                                    lon = (180 * number) / 324000000.0;
                                    degrees = (int)lon;
                                    minutes = 60 * (lon - degrees);
                                    longStr = string.Format("{0}º{1}{2}", degrees, minutes, (((WriteDBMessageLocation)row).courseStatus[0] & 0x08) == 0 ? "E" : "W");
                                    cmdLocation.Parameters["@Longitude"].Value = longStr;
                                    number = BitConverter.ToUInt32(((WriteDBMessageLocation)row).lattitude.Reverse().ToArray(), 0);
                                    lat = (90 * number) / 162000000.0;
                                    degrees = (int)lat;
                                    minutes = 60 * (lat - degrees);
                                    latStr = string.Format("{0}º{1}{2}", degrees, minutes, (((WriteDBMessageLocation)row).courseStatus[0] & 0x04) == 0 ? "S" : "N");
                                    cmdLocation.Parameters["@Lattitude"].Value = latStr;
                                    cmdLocation.Parameters["@speed"].Value = ((WriteDBMessageLocation)row).speed;
                                    rowsAdded = cmdLocation.ExecuteNonQuery();
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error : '{0}'", ex.Message);
                    }
                    timer.Enabled = true;
                }
            }
            public void StartListening(string IP, int port, Boolean test)
            {
                try
                {
                    // Establish the local endpoint for the socket.
                    // The DNS name of the computer
                    // running the listener is "host.contoso.com".
                    IPHostEntry ipHostInfo = Dns.GetHostEntry(IP);  //Dns.Resolve(Dns.GetHostName());
                    IPAddress ipAddress = ipHostInfo.AddressList[0];
                    //IPAddress local = IPAddress.Parse(IP);
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
                    allDone.Reset();
                    acceptDone.Reset();
                    listener.Bind(localEndPoint);
                    listener.Listen(100);
                    //login code, wait for 1st message
                    Console.WriteLine("Wait 5 seconds for login message");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
