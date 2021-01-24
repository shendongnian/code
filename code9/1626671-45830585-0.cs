    public ReadDataBlockString_Result ReadDataBlockString(int DataBlockNumber, 
    int StartAddress, int LenghtOfRead)
            {
                ReadDataBlockString_Result rt = new ReadDataBlockString_Result();
                rt.MemoryByte = new byte[256];
                //if (this.State == PLCClientConnectState.Connected)
                //{
                    rt.DataValue = new string[LenghtOfRead];
                    int i = 0;
                    int CaptureIndex = StartAddress;
                    for (i = 0; i <= LenghtOfRead - 1; i++)
                    {
                        rt.ResultCode = PLCClient.DBRead(DataBlockNumber, CaptureIndex, 256, rt.MemoryByte);
                        CaptureIndex = CaptureIndex + 256;
                        if (rt.ResultCode == 0)
                        {
                            string Convertedvalue = null;
                            Convertedvalue = System.Text.Encoding.ASCII.GetString(rt.MemoryByte);
                            rt.DataValue[i] = Convertedvalue;
                        }
                    }
                //}
                //else
                //{
                //    rt.ResultCode = -1;
                //}
                rt.ReSultString = PLCClient.ErrorText(rt.ResultCode);
                return rt;
            }
