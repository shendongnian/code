        BackgroundTaskDeferral _deferral = null;
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();
            // 
            // TODO: Insert code to start one or more asynchronous methods 
            //
            try
            {
                //var u = new USART();
                //await u.Initialize(115200, SerialParity.None, SerialStopBitCount.One, 8);
                listOfDevices = new ObservableCollection<DeviceInformation>();
                ListAvailablePorts();
            }
            
            ...
        }
