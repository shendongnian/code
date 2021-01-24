    private void Arduino_Write(string Output) {
            if (!(networkStream == null)) {
                Byte[] sendBytes = Encoding.ASCII.GetBytes(Output);
                Byte[] endByte;
                254;
                networkStream.Write(sendBytes, 0, sendBytes.Length);
                networkStream.Write(endByte, 0, 1);
            }
            else {
                MsgBox("ERROR");
            }
            
        }
