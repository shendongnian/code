        private void auditLog(string user)
        {
			// Get logs from event viewer
            string userName = ExtractUserAlias(user);
            EventLog securityLog = new EventLog("Security");
            var logOnAttempts = (
                    from log in securityLog.Entries.Cast<EventLogEntry>()
                    where log.EventID == 4625 || log.EventID== 4624 && log.ReplacementStrings[5] == userName
                    orderby log.TimeGenerated descending
                    select log
                ).Take(20).ToList();
            //Store user logs to db if logs does not exists.
			//Store in DB for reporting purposes
            DataAccess db = new DataAccess();
            foreach (var x in logOnAttempts)
            {
                string entryType = "";
                switch (x.EntryType)
                {
                    case EventLogEntryType.SuccessAudit:
                        entryType = "SuccessAudit";
                            break;
                    case EventLogEntryType.FailureAudit:
                        entryType = "FailureAudit";
                        break;
                }
                
                SqlCommand com = new SqlCommand();
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = "Sp_LogUser";
                com.Parameters.AddWithValue("@UserName", userName);
                com.Parameters.AddWithValue("@EntryType", entryType);
                com.Parameters.AddWithValue("@TimeGenerated", x.TimeGenerated);
                com.Parameters.AddWithValue("@Details", x.Message);
                db.ExecuteNonQuery(com);
            }
            // logic to to validate and lock user
            SqlCommand com2 = new SqlCommand();
            com2.CommandType = System.Data.CommandType.StoredProcedure;
            com2.CommandText = "Sp_validateAndLockUser";
            com2.Parameters.AddWithValue("@Username", @userName);
            db.ExecuteNonQuery(com2);
            
        }
