                cmd.CommandText = "SELECT Teacher_Name, Standard, Subject, Balance_Slot FROM GroupOdd order by sum_weekly_slot desc";
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
                int group = 0;
                if (dt.Rows.Count == 0)
                {
                    cmd2.CommandText = "INSERT INTO group_odd_" + group + " (Teacher_Name, Standard, Subject) VALUES (@Teacher_Name, @Standard, @Subject)";
                    cmd2.Parameters.AddWithValue("@Teacher_Name", dr["Teacher_Name"].ToString());
                    cmd2.Parameters.AddWithValue("@Standard", dr["Standard"].ToString());
                    cmd2.Parameters.AddWithValue("@Subject", dr["Subject"].ToString());
                    cmd2.CommandText = "Update GroupOdd set Balance_Slot = Balance_Slot - 1 WHERE Teacher_Name = @Teacher_Name AND Standard = @Standard AND Subject = @Subject";
                    cmd2.Parameters.AddWithValue("@Teacher_Name", dr["Teacher_Name"].ToString());
                    cmd2.Parameters.AddWithValue("@Standard", dr["Standard"].ToString());
                    cmd2.Parameters.AddWithValue("@Subject", dr["Subject"].ToString());
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    if (!Balance_Slot.IsNullOrEmpty())
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            for (int j = 1; j <= 9; j++)
                            {
                                //bool TeacherNameExist = true;
                                DataTable dt2 = new DataTable();
                                cmd2.CommandText = "SELECT * FROM group_odd_" + j + " WHERE (Teacher_Name == @Teacher_Name OR Standard == @Standard OR Subject == @Subject)";
                                cmd2.Parameters.AddWithValue("@Teacher_Name", dr["Teacher_Name"].ToString());
                                cmd2.Parameters.AddWithValue("@Standard", dr["Standard"].ToString());
                                cmd2.Parameters.AddWithValue("@Subject", dr["Subject"].ToString());
                                SQLiteDataAdapter da2 = new SQLiteDataAdapter(cmd2);
                                da2.Fill(dt2);
                            }
                        }
                    }
                }
