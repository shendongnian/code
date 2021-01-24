        private void connect()
    {
        Logger.log("Connecting to ...", machine.getMachineInfo());
		
		getDeviceApi().OnConnected += new _IZKEMEvents_OnConnectedEventHandler(onConnected);
        getDeviceApi().OnDisConnected += new _IZKEMEvents_OnDisConnectedEventHandler(onDisConnected);
		
        Boolean isConnected = getDeviceApi().Connect_Net(this.machine.ip, this.machine.port);
        if (isConnected)
        {
            connectionTryCount = 0;
            Logger.log("Connected!");
            if (getDeviceApi().RegEvent(this.machine.machineCode, 65535))
            {
                getDeviceApi().OnAttTransactionEx += new _IZKEMEvents_OnAttTransactionExEventHandler(onAttendanceTransaction);
            }
        }
	}
