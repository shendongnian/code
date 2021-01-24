        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Dymo
            PrintersComboBox.ItemsSource = DYMO.Label.Framework.Framework.GetLabelWriterPrinters();
            PrintersComboBox.SelectedIndex = 0;
            //NFC
            Environment.SpecialFolder nSpecialFolderLocalUser = Environment.SpecialFolder.LocalApplicationData;
            string sDataFolderUser = Environment.GetFolderPath(nSpecialFolderLocalUser);
            Debug.WriteLine("Local registry (option): " + Path.Combine(sDataFolderUser, "Subsembly" + Path.DirectorySeparatorChar + "SmartCard" + Path.DirectorySeparatorChar + "registry.xml"));
            // shared folder example C:\ProgramData\Subsembly\SmartCard\Registry.xml
            Environment.SpecialFolder nSpecialFolderShared = Environment.SpecialFolder.CommonApplicationData;
            string sDataFolderShared = Environment.GetFolderPath(nSpecialFolderShared);
            Debug.WriteLine("Common registry: " + Path.Combine(sDataFolderShared, "Subsembly" + Path.DirectorySeparatorChar + "SmartCard" + Path.DirectorySeparatorChar + "registry.xml"));
            // FYI section end
            //Create the potentialy event during the test
            CardTerminalManager.Singleton.CardInsertedEvent +=
              new CardTerminalEventHandler(InsertedEvent);
            CardTerminalManager.Singleton.CardRemovedEvent +=
              new CardTerminalEventHandler(RemovedEvent);
            CardTerminalManager.Singleton.CardTerminalLostEvent +=
                new CardTerminalEventHandler(TerminalLostEvent);
            CardTerminalManager.Singleton.CardTerminalFoundEvent +=
                new CardTerminalEventHandler(TerminalFoundEvent);
            try
            {
                //Init SerialPort for EnOcean
                SerialPort mySerialPort = new SerialPort("COM3");
                mySerialPort.BaudRate = 57600;
                mySerialPort.RtsEnable = true;
                mySerialPort.DtrEnable = true;
                mySerialPort.Open();
                mySerialPort.DataReceived +=
                    new SerialDataReceivedEventHandler(DataReceivedHandler);
            }
            catch
            {
                MessageBox.Show(
                    "Unable to connect the port COM3, " +
                    " exit this application.",
                    "Impulse sensor test",
                    MessageBoxButton.OK,
                    MessageBoxImage.Stop);
                Application.Current.Shutdown();
            }
            if (!StartupCardTerminalManager())
            {
                Application.Current.Shutdown();
            }
  
        }
        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //init serialport comport
            SerialPort comport = (SerialPort)sender;
            // Shortened and error checking removed for brevity...
            int bytes = comport.BytesToRead;
            byte[] buffer = new byte[bytes];
            comport.Read(buffer, 0, bytes);
            Thread.Sleep(500);
            HandleSerialData(buffer, comport);
        }
        public void HandleSerialData(byte[] respBuffer, SerialPort comport)
        {
            byte[] buffer = new byte[4];
            DateTime LocalDate = DateTime.Now;
            for (int i = 0; i < 4; i++)
            {
                buffer[i] = respBuffer[i + 11];
            }
            StringBuilder hex = new StringBuilder(buffer.Length * 2);
            foreach (byte b in buffer)
                hex.AppendFormat("{0:x2}", b);
            string hex2 = hex.ToString();
            Dispatcher.BeginInvoke((Action)(() => { EnOcean_Label.Content = hex2; }));
            Dispatcher.BeginInvoke((Action)(() => { EnOcean2_Label.Content = hex2; }));
            List<User> users = new List<User>();
            users.Add(new User() { NumeroTIC = hex2, NumeroCNT1 = hex2, Date = LocalDate});
            Dispatcher.BeginInvoke((Action)(() => { dgSimple.ItemsSource = users; }));
            //WriteTest(ID_TIC);
        }
