                List<int> list = new List<int>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(Convert.ToInt32(dr["Qulif_code"]));
                    
                }
                int[] arr = list.ToArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 1)
                    {
                        ck_ol.Checked = true;
                    }
                    else if (arr[i] == 2)
                    {
                        ck_al.Checked = true;
                    }
                    else if (arr[i] == 3)
                    {
                        ck_dip.Checked = true;
                    }
                    else if (arr[i] == 4)
                    {
                        ck_deg.Checked = true;
                    }
                }          
