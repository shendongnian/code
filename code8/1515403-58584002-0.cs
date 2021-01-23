                            if (Sql.State == ConnectionState.Closed)
                            {
                                Sql.Open();
                            }
                            SqlCommand a1 = new SqlCommand("Select FingerPrint,[REF NO] 
                            from Members", Sql);
                            SqlDataReader SDR = a1.ExecuteReader();
                            while (SDR.Read())
                            {
                                ret = fpInstance.Match(CapTmp, (byte[])(SDR[0]));
                                if (ret > 30)
                                {
                                    a = SDR[1].ToString();
                                    break;
                                }
                            }
