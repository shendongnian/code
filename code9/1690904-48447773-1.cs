               SqlConnection CON = new SqlConnection(Testdb);
            {
                CON.Open();
                string ShiftTime = "SELECT count(discard) as alert FROM [Rejected].[dbo].[InQuestion] where discard = '0'";
                SqlCommand ShiftTimecalculate = new SqlCommand(ShiftTime, CON);
                SqlDataReader readershifttime =
                ShiftTimecalculate.ExecuteReader();
                readershifttime.Read();
                if (readershifttime.hasrows)
                {
                    Notifyme.Text = readershifttime["alert"].ToString();
                    readershifttime.Close();
                }
            }
