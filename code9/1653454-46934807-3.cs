    private static void TestGetRecordsAndDump()
    {
        const string FILE_NAME = "Records.CSV";
        File.Delete(FILE_NAME);
        var file = File.AppendText(FILE_NAME);
        long count = 0;
        try
        {
            ServiceReference1.ServiceClient service = new ServiceReference1.DataServiceClient();
            var stream = service.GetDBRowStream();
            Console.WriteLine("Records Retrieved : ");
            Console.WriteLine("File Size (MB)    : ");
            var canDoLastRead = true;
            while (stream.CanRead && canDoLastRead)
            {
               try
               {
                   Customer customer = DBDataFormatter.Deserialize(stream); // Used custom Deserializer, but BinaryFormatter should be fine
                   file.Write(customer.ToString());
                   count++;
               }
               catch
               {
                    canDoLastRead = false; // Bug: stream.CanRead is not set to false at the end of stream, so I do this trick to know if I finished retruning all records.
               }
               finally
               {
                   Console.SetCursorPosition("Records Retrieved : ".Length, 0);
                   Console.Write(string.Format("{0}               ", count));
                   Console.SetCursorPosition("File Size (MB)    : ".Length, 1);
                   Console.Write(string.Format("{0:G}             ", file.BaseStream.Length / 1024f / 1024f));     
               }
            }
            finally
            {
                file.Close();
            }
        }
    }
