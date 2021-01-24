            public static string Getdata()
        {
            try
            {
                byte[] DataLengthinBytes = new byte[4];
                nwStream.Read(DataLengthinBytes, 0, 4);
                int DataLength = BitConverter.ToInt32(DataLengthinBytes, 0);
                byte[] bytesToRead = new byte[DataLength];
                StringBuilder str = new StringBuilder();
                int bytesRead = 0;
                int i = 0;
                while(i < DataLength){
                    bytesRead = nwStream.Read(bytesToRead, 0, DataLength);
                    str.AppendFormat("{0}", Encoding.GetEncoding("ISO-8859-1").GetString(bytesToRead, 0, bytesRead));
                    i += bytesRead;
                }
                return str.ToString();
            }
            catch (Exception)
            {
                return "Did not recieved anything from Virtual PC";
            }
        }
