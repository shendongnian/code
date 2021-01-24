     DataTable dt = auc.GetTradesByDate().Tables[0];
            /**************************************************************/
            StringBuilder sb = new StringBuilder();
          
                sb.AppendFormat("{0},{1},{2},{3},{4}"
                    , "date", "symbol", "symbolName", "buyerId","buyerName\n");
                foreach (DataRow dr in dt.Rows)
                {
                    sb.AppendFormat("{0},", dr["date"]);
                    sb.AppendFormat("{0},", dr["symbol"]);
                    sb.AppendFormat("{0},", dr["symbolName"]);
                    sb.AppendFormat("{0},", dr["buyerId"]);
                    sb.AppendFormat("{0}", dr["buyerName"]);
                    sb.AppendFormat("\n");
                }
                string CsvHeader = "";
                Response.Clear();
                Response.ContentType = "text/csv";
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment;filename=trades_{0}-{1}-{2}.csv", DateTime.Now.Year, DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00")));
                Response.Write(CsvHeader + sb.ToString());
                Response.End();
            
