    static void sendMessage(string c_1)
        {
            byte[] command = Encoding.ASCII.GetBytes(c_1);
            byte[] commandLength = Encoding.ASCII.GetBytes(command.Length.ToString());
            List<byte> commandLengthInByteArray = commandLength.ToList();
            while (true)
            {
                if (commandLengthInByteArray.ToArray().Length < 50)
                {
                    commandLengthInByteArray.Add(Convert.ToByte('x'));
                }
                else
                {
                    break;
                }
            }
            byte[] parsedCommandLength = commandLengthInByteArray.ToArray();
            sck.Send(parsedCommandLength);
            sck.Send(command);
        }
        static void sendMessage_ftp(byte[] data)
        {
            byte[] commandLength = Encoding.ASCII.GetBytes(data.Length.ToString());
            List<byte> commandLengthInByteArray = commandLength.ToList();
            while (true)
            {
                if (commandLengthInByteArray.ToArray().Length < 50)
                {
                    commandLengthInByteArray.Add(Convert.ToByte('x'));
                }
                else
                {
                    break;
                }
            }
            byte[] parsedCommandLength = commandLengthInByteArray.ToArray();
            sck.Send(parsedCommandLength);
            sck.Send(data);
        }
    static byte[] getResponse(Socket sck)
        {
            byte[] CommandLengthInByteArray = ReadBytes(50, sck);
            List<byte> commandLengthInByteArrayList = new List<byte>();
            foreach (byte b in CommandLengthInByteArray)
            {
                if (b.ToString() != "120")
                {
                    commandLengthInByteArrayList.Add(b);
                }
            }
            Int32 fileSize = Convert.ToInt32(Encoding.ASCII.GetString(commandLengthInByteArrayList.ToArray()));
            byte[] data = ReadBytes(fileSize, sck);
            return data;
        }
        static byte[] ReadBytes(Int32 size, Socket sck)
        {
            //The size of the amount of bytes you want to recieve, eg 1024
            var bytes = new byte[size];
            Int32 total = 0;
            do
            {
                var read = sck.Receive(bytes, total, size - Convert.ToInt32(total), SocketFlags.None);
                if (read == 0)
                {
                    //If it gets here and you received 0 bytes it means that the Socket has Disconnected gracefully (without throwing exception) so you will need to handle that here
                }
                total += read;
                //If you have sent 1024 bytes and Receive only 512 then it wil continue to recieve in the correct index thus when total is equal to 1024 you will have recieved all the bytes
            } while (total != size);
            return bytes;
        }
