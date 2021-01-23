      //ZERO ERRO CHECKING.
        private static void SaveMessage(MailMessage message, byte[] arr)
        {
            using (var conn = new SqlConnection("CONNECTION_STRING"))
            {
                using (var cmd = new SqlCommand("INSERT INTO MailSent (Body,Attachment) VALUES(@BODY,@ATTACHMENT)", conn))
                {
                    conn.Open();
                    var param = new SqlParameter("@BODY", SqlDbType.VarChar)
                    {
                        Value = message.Body
                    };
                    var param2 = new SqlParameter("@ATTACHMENT", SqlDbType.Binary)
                    {
                        Value = arr
                    };
                    cmd.Parameters.Add(param);
                    cmd.Parameters.Add(param2);
                    cmd.ExecuteNonQuery();
                }
            }            
        }
