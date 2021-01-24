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
                    cmdLocation.Parameters.Add("@Longitude", SqlDbType.NVarChar, 50);
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
                                    locationMessage.IMEI = byteState.Value.IMEI;
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
