                    if (dt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            d4.Rows.Add(dt1.Rows[i][0], dt1.Rows[i][1], dt1.Rows[i][2], dt1.Rows[i][3], dt1.Rows[i][4], dt2.Rows[i][3]);
                           
                            grdVehicleUtilization.DataSource = d4;
                            grdVehicleUtilization.DataBind();
                        }
                       
                    }`
