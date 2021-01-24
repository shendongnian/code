    public static void Run(TraceWriter log, ICollector<SMSMessage> smsmessage) 
    {
       string phonenumber = "";
       string MessageBody = "sample message";
       using (SqlConnection conn = new SqlConnection(str))
       {
            conn.Open();
            var sqlStr = "SELECT [phone] FROM [dbo].[tbl_ContactTable] where [ID] = 2";  //It returns two rows with twilio verified phone numbers
             using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
             {
                var dataReader = cmd.ExecuteReader();
                if(dataReader.HasRows)
                { 
                  while(dataReader.Read())
                  {
                     var sms = new SMSMessage();  //changed code
                     phonenumber = dataReader[0].ToString();
                     log.Info($" phonenumber {phonenumber}");
                     sms.Body = MessageBody;
                     sms.To = phonenumber;
                     smsmessage.Add(sms); //changed oode
                   }
                  
                 }
                  dataReader.Close();
            }
                  conn.Close();
         }
      }
