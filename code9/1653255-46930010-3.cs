        SerialPortHandler spHandler;
        public void Init()
        {
            SerialPortHandler spHandler = new SerialPortHandler("COM1", IsReport, DequeueResponse);
            spHandler.OnReport += SpHandler_OnReport;
        }
        bool IsReport(byte[] data)
        {
            //Determines whether the command is Cmd_Reprot
            return true;
        }
        byte[] DequeueResponse(Queue<byte> quReceive)
        {
            byte[] response = null;
            //Dequeuing a valid response based protocol rules
            return response;
        }
        private void SpHandler_OnReport(byte[] data)
        {
            if (DataEqual(Cmd_Report, CMD_REPORT))
            {
                //do something X about data then save data
            }
        }
        public void DoWork()
        {
            //do something 
            byte[] Cmd_Req = null;
            byte[] Cmd_Res = new byte[CMD_RES.Length];
            int ret = spHandler.SendCommand(Cmd_Req, Cmd_Req, 1000);
            if (ret > 0 && DataEqual(Cmd_Res, CMD_RES))
            {
                //create data, do something A about data
            }
            else
            {
                //do something B
            }
        }
