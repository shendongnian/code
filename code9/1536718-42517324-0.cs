        Dictionary<string, string> MonthsDic = new Dictionary<string, string>();
                    MonthsDic.Add("1", "فروردین");
                    MonthsDic.Add("2", "اردیبهشت");
                    MonthsDic.Add("3", "خرداد");
                    MonthsDic.Add("4", "تیر");
                    MonthsDic.Add("5", "مرداد");
                    MonthsDic.Add("6", "شهریور");
                    MonthsDic.Add("7", "مهر");
                    MonthsDic.Add("8", "آبان");
                    MonthsDic.Add("9", "آذر");
                    MonthsDic.Add("10", "دی");
                    MonthsDic.Add("11", "بهمن");
                    MonthsDic.Add("12", "اسفند");
    
    ///
    private void LoadMonthlyReport()
    {
    DataTable dt = new DataTable();
                SqlCommand s = new SqlCommand("ReportMonthly", SCon);
                s.CommandType = CommandType.StoredProcedure;
                s.Parameters.AddWithValue("@Year", Year);
                SCon.Open();
                SqlDataReader dr = s.ExecuteReader();
                dt.Load(dr);            
                dt.Columns.Add("MonthName", typeof(string));
                foreach (DataRow d in dt.Rows)
                {
                    switch (d["Month"].ToString())
                    {
                        case "1":
                            d["MonthName"] = "فروردین";
                            break;
                        case "2":
                            d["MonthName"] = "اردیبهشت";
                            break;
                        case "3":
                            d["MonthName"] = "خرداد";
                            break;
                        case "4":
                            d["MonthName"] = "تیر";
                            break;
                        case "5":
                            d["MonthName"] = "مرداد";
                            break;
                        case "6":
                            d["MonthName"] = "شهریور";
                            break;
                        case "7":
                            d["MonthName"] = "مهر";
                            break;
                        case "8":
                            d["MonthName"] = "آبان";
                            break;
                        case "9":
                            d["MonthName"] = "آذر";
                            break;
                        case "10":
                            d["MonthName"] = "دی";
                            break;
                        case "11":
                            d["MonthName"] = "بهمن";
                            break;
                        case "12":
                            d["MonthName"] = "اسفند";
                            break;
                    }
                }
                chtWRMonthly.DataSource = dt;
                chtWRMonthly.Series["Sold"].XValueMember = "MonthName";
                chtWRMonthly.Series["sRemaining"].XValueMember = "MonthName";
                chtWRMonthly.Series["Bought"].XValueMember = "MonthName";
                chtWRMonthly.Series["bRemaining"].XValueMember = "MonthName";
                chtWRMonthly.Series["Sold"].YValueMembers = "sTAccount";
                chtWRMonthly.Series["sRemaining"].YValueMembers = "sRemaining";
                chtWRMonthly.Series["Bought"].YValueMembers = "bTAccount";
                chtWRMonthly.Series["bRemaining"].YValueMembers = "bRemaining";
                SCon.Close();
    }
