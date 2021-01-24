        [MTAThread]
        static void Main(string[] args)
        {
            //check if the app is already running
            running = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1;
            Console.WriteLine("ALready running? " + running);
            if (running)
            {
                string selected = null;
                if (args.Length == 1) //apertura da context menu
                {
                    selected = args[0];
                    pathSend = selected;
                }
                // open the memory-mapped 
                MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("myMappedFile");
                // declare accessor to write on file
                MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor();
                if (selected != null)
                {
                    //write in the file: Length|Path
                    //4 offset cause length is on 32 bit
                    byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(selected);
                    accessor.Write(0, Buffer.Length);
                    accessor.Flush();
                    accessor.WriteArray(4, Buffer, 0, Buffer.Length);
                    accessor.Flush();
                    //write path in the memory mapped file
                }
                else
                {
                    //write in the file: Lenght|Path
                    accessor.Write(0, 0);
                }
                //MessageBox.Show("Application already running in background!!!");
                closing = false;
            }
            else {
                if (!closing)// there are no process active
                {
                    // create a memory-mapped file of length 1000 bytes and give it a 'map name' of 'test'
                    MemoryMappedFile mmf = MemoryMappedFile.CreateNew("myMappedFile", 1000);
                    string selected = null;
                    if (args.Length == 1) //apertura da context menu
                    {
                        selected = args[0];
                        pathSend = selected;
                    }
                    Console.WriteLine("ALready running: opening " + pathSend);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    //create userManagerUnit
                    umu = new UserManagerUnit();
                    //create a ManualResetEvent used from Server's Threads
                    // true -> server start work  ||  false -> server stop work
                    mre = new ManualResetEvent(true);
                    // create Server istance
                    //  active server
                    server = new Server();
                    serverThread = new Thread(server.EntryPoint) { Name =   "serverThread" };
                    serverThread.IsBackground = true;
                    serverThread.Start();
                    //create new client
                    client = new Client();
                    // create gui istance
                    gui = new GUI(selected);
                    //run application
                    Application.Run(gui);
                    
                }
            }    
        }
