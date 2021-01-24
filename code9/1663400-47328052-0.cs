                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (tmpemp == int.Parse( reader["mst_sq"].ToString() ) )
                        {}
                        else
                        {
                            if (noofusers >1)
                            {
                                f.Add(d);
                            }
                            col = 0;
                            noofusers = noofusers + 1;
                            tmpemp = int.Parse(reader["mst_sq"].ToString());
                            d.UserName = reader["mst_firstname"].ToString() + " " + reader["mst_lastname"].ToString();
                            d.StartTime = reader["starttime"].ToString();
                            d.Department = reader["dept_name"].ToString();
                        }
                        if (reader["dy"].Equals(System.DBNull.Value))
                        {}
                        else
                        {
                            d1.ClockingDate = reader["dy"].ToString().Substring(0, 4) + reader["dy"].ToString().Substring(5, 2) + reader["dy"].ToString().Substring(8, 2);
                            d1.MinInEarly = reader["mnearly"].ToString();
                            d1.MinInEarly = reader["mnlate"].ToString();
                            d1.InClockingTime = reader["tmeclocked"].ToString().Substring(11, 5);
                            d1.OutClockingTime = reader["earlyclocked"].ToString().Substring(11, 5);
                            d2.Add(d1);
                        }
                        col = col + 1;
                        d.NoofDaysClocked = col;
                    }
                    f.Add(new f.DailyClockings( d2));
                    f.Add(d);
