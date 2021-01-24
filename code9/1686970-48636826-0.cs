    public partial class DataPublisherForm : Form
    {
        private ZContext zmqContext;                 // a Context() class-instance
        private ZSocket sensorDataPublisher;         // a Socket()  class-instance
     // -------------------------------------------- // this.VERSION details
        private int     majorVerNUM,
                        minorVerNUM,
                        patchVerNUM;
        
        private string libzmqVerSTR;
     // -------------------------------------------- //
        public DataPublisherForm()                   // CONSTRUCTOR:
        {
            zmqContext = new ZContext();
            zmq.zmq_version( this.majorVerNUM,       // Ref. a trailer note:
                             this.minorVerNUM,
                             this.patchVerNUM
                             );
            this.libzmqVerSTR = string.Format( "libzmq DLL is version {0}",
                                                zmq.LibraryVersion()
                                                );
            
            mySensor = new Sensor();
            mySensor.DataArrived += OnDataArrived;
            
            sensorDataPublisher = new ZSocket(zmqContext, ZSocketType.PUB);
            sensorDataPublisher.SetOption(ZSocketOption.CONFLATE, 1);
            sensorDataPublisher.Bind("tcp://*:10000");
        }
        
        private void OnDataArrived(object sender, DataArrivedEventArgs e)
        {
            byte[] sensorData = e.getSenorData();
            sensorDataPublisher.Send(new ZFrame(sensorData));
        }
    
        private void DataPublisherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sensorDataPublisher != null)
            {   sensorDataPublisher.SetOption( ZSocketOption.LINGER, 0 );
                sensorDataPublisher.Close();
                sensorDataPublisher.Dispose();
            }
         // -------------------------<NEVER BEFORE SAFE DISMANTLING ALL SOCKETS>---
            zmqContext.Shutdown();                   // optional  API-call
            zmqContext.Terminate();                  // mandatory API-call
        }
     // -------------------------------------------- // VERSION CONTROL METHODS
        public  string  getDllVersionSTRING()        // a DLL version
        {   return this.libzmqVerSTR;
        }
        public  int getVersionMAJOR()                // a version() responder
        {   
            return this.majorVerNUM;
        }
        public  int getVersionMINOR()                // a version() responder
        {   
            return this.minorVerNUM;
        }
        public  int getVersionPATCH()                // a version() responder
        {   
            return this.patchVerNUM;
        }
    }
