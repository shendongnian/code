         public class USB_COMM 
            {
                static private SerialPort SPRT = new SerialPort();
                static String ComPortName = "";
                static int BaudRate = 0;
                public USB_COMM(String sCOMNAME, int iBaudRate)
                {
                    ComPortName = sCOMNAME;
                    BaudRate = iBaudRate;
                    Sckt1 = new Socket(SocketType.Stream,ProtocolType.Tcp);
                    Server();
                    Sckt1.Connect(IPAddress.Parse("127.0.0.1"), 5000);
                    mns= new myStream();
                }
            public NetworkStream NsGetUsbStrm()
            {
                return mns;
            }
    
    
                private class myStream : NetworkStream
                {
                    public myStream()
                        : base(Sckt1)
                    {
                        SPRT.PortName = ComPortName;
                        SPRT.BaudRate = BaudRate;
                    }
                    public int iOpenPort()
                    {
                        try {
                            SPRT.Open();
                            return 0;
                        }
                        catch
                        {
                            return 1;
                        }
                    }
                    public override bool DataAvailable
                    {
                        get
                        {
                            int AvilBytes = SPRT.BytesToRead;
                            if (AvilBytes > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    protected override void Dispose(bool disposing)
                    {
                        base.Dispose(disposing);
                    }
                    public override int Read(byte[] buffer, int offset, int size)
                    {
        
                        if (buffer == null || offset < 0 || size < 0)
                        {
                            throw new ArgumentException();
                        }
                        if (!SPRT.IsOpen)
                            SPRT.Open();
                        return SPRT.Read(buffer, offset, size);
                        //return base.Read(buffer, offset, size);
                    }
                    public override void Write(byte[] buffer, int offset, int size)
                    {
        
                        if (buffer == null || offset < 0 || size < 0)
                        {
                            throw new ArgumentException();
                        }
                        if (!SPRT.IsOpen)
                            SPRT.Open();
                        SPRT.Write(buffer, offset, size);
                        //base.Write(buffer, offset, size);
                    }
                }
                private void Server()
                {
                    const int PORT_NO = 5000;
                    const string SERVER_IP = "127.0.0.1";
        
                    //---listen at the specified IP and port no.---
                    IPAddress localAdd = IPAddress.Parse(SERVER_IP);
                    TcpListener listener = new TcpListener(localAdd, PORT_NO);
                    Console.WriteLine("Listening...");
                    listener.Start();
             
                }
             
            }
