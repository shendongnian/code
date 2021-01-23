        string WSMSconnectionstring = @"Data Source=MHAMUDUL\WALTON;Initial Catalog=WSMS;Integrated Security=True";
    //Or
       // string WSMSconnectionstring = @"Data Source=MHAMUDUL\WALTON;Initial Catalog=WSMS;Persist Security Info=True;User ID=sa;Password=ssssss";
         using (SqlConnection con = new SqlConnection(WSMSconnectionstring))
                             {
                                con.Open();
                                string query1 = String.Format(@" Select * from ServiceTimeLog where ServiceID={0} and QCReleaseStatus is  null
         ", ServiceID);
                                SqlCommand cmd1 = new SqlCommand(query1, con);
                                SqlDataReader reader = cmd1.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    reader.Dispose();
                                    //Update
                                    string update = String.Format(@" update  ServiceTimeLog set ServiceDate=GETDATE(), StartTime=GETDATE(),EndTime=GETDATE(),QCStartTime=GETDATE(),QCEndTime=GETDATE(),QCReleaseStatus='QCPassed',ReleaseStatus='SendToQC',TechnicianID=(select UserID from Users where UserName='{0}'),QCID=(select UserID from Users where UserName='{1}') where ServiceID={2}", TechnicainID, QCID, ServiceID);
                                    SqlCommand updateCmd = new SqlCommand(update, con);
                                    updateCmd.ExecuteNonQuery();
        
                                }
                                else
                                {
                                    reader.Dispose();
                                    //Insert
                                    string insert = String.Format(@"insert into ServiceTimeLog(ServiceID,ReleaseStatus,ServiceDate,StartTime,EndTime,QCStartTime,QCEndTime,QCReleaseStatus,TechnicianID,QCID)  values({0},'SendToQC',GETDATE(),GETDATE(),GETDATE(),GETDATE(),GETDATE(),'QCPassed',(select UserID from Users where UserName='{1}'),(select UserID from Users where UserName='{2}'))", ServiceID, TechnicainID, QCID);
                                    SqlCommand insertCmd = new SqlCommand(insert, con);
                                    insertCmd.ExecuteNonQuery();
                                }
                                cmd1.Dispose();
                                reader.Dispose();
                            }
