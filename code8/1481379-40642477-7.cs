        //ZERO ERROR CHECKING.
        private static void GetMailMessage(int itemId, ref MailMessage msg2, ref byte[] arr2)
        {
            using (var conn = new SqlConnection("CONNECTION_STRING"))
            {
                using (var cmd = new SqlCommand("SELECT [Body],[Attachment] FROM MailSent WHERE ID = @itemId", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@itemId", itemId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            msg2.Body = dr[0].ToString();
                            arr2 = dr[1] as byte[];
                        }
                    }
                }
            }
        }
