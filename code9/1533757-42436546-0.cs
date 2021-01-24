    foreach (DataTable table in ds8.Tables)
                    {
    
                        foreach (DataRow dr in table.Rows)
                        {
                            String S = Convert.ToString(dr["EMP_CODE"].ToString());
                            foreach (ListItem item in CheckBoxList2.Items)
                            {
                                if (S == item.Value)
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                    }
