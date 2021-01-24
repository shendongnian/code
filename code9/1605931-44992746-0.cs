            string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\LicensedDB.accdb;
            Persist Security Info=True;Jet OLEDB:Database Password=abc123";
            using (OleDbConnection con = new OleDbConnection(constring))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT TaskDetails FROM TaskReminder ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter sda = new OleDbDataAdapter(cmd))
                    {
                            sda.Fill(dtReminders);    
                            if(dtReminders.Rows.Count > 0)
                              timer.Start();
                    }
                }
            }
        }
