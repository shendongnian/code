    static class Program
    {
        const string AppId = "Local\\1DDFB948-19F1-417C-903D-BE05335DB8A4"; // Unique par application 
        [STAThread]
        static void Main(string[] args)
        {
            using (var mutex = new Mutex(false, AppId))
            {
                if (!mutex.WaitOne(0))
                {
                    // 2nd instance
                    // Send the command line to the first instance
                    IpcChannel clientChannel = new IpcChannel();
                    ChannelServices.RegisterChannel(clientChannel, false);
                    SingleInstance app = (SingleInstance)Activator.GetObject(typeof(SingleInstance), string.Format("ipc://{0}/RemotingServer", AppId));
                    app.Execute(args);
                    return;
                }
                // 1st instance
                // Register the IPC server
                IpcChannel channel = new IpcChannel(AppId);
                ChannelServices.RegisterChannel(channel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(SingleInstance), "RemotingServer", WellKnownObjectMode.Singleton);
                // Start the application
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
        private class SingleInstance : MarshalByRefObject
        {
            public void Execute(string[] args)
            {
                // TODO use the args sent by the second instance
            }
        }
    }
