     private void gvTurnOffNotifications_SelectionChanged(object sender, EventArgs e)
            {
                if (gvTurnOffNotifications.SelectedCells.Count > 0)
                {
                    int selectedrowindex = gvTurnOffNotifications.SelectedCells[0].RowIndex;
    
                    DataGridViewRow selectedRow = gvTurnOffNotifications.Rows[selectedrowindex];
    
                    getUserSelected = Convert.ToString(selectedRow.Cells["UserName"].Value);
    
                    MessageBox.Show(getUserSelected);
    
                    foreach (DataGridViewRow row in gvTurnOffNotifications.Rows)
                    {
                        DataGridViewCheckBoxCell cell = row.Cells[1] as DataGridViewCheckBoxCell;
    
                        //We don't want a null exception!
                        if (cell.Value != null)
                        {
                            //It's checked!
                            btnUpdateTurnOff.Enabled = true;
                            myConnectionString = ConfigurationManager.ConnectionStrings["FSK_ServiceMonitor_Users_Management.Properties.Settings.FSK_ServiceMonitorConnectionString"].ConnectionString;
                            using (mySQLConnection = new SqlConnection(myConnectionString))
                            {
                                bool change = false;
    
                                string procedureName = "update UsersNotified Set AllowNotification='" + change + "' where UserName='" + getUserSelected + "'";
                                //MessageBox.Show(cell.Value.ToString());
                                mySQLCommand = new SqlCommand(procedureName, mySQLConnection);
                                mySQLCommand.CommandType = CommandType.Text;
                                mySQLCommand.Connection = mySQLConnection;
                                mySQLCommand.Connection.Open();
                                mySQLCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
