               //Your Data table
                DataTable dt = new DataTable();
                //Let you have following columns
                dt.Columns.Add("Id");
                dt.Columns.Add("FromDate");
                dt.Columns.Add("ToDate");
           //Adding rows in data table
            dt.Rows.Add(1, "2017-06-27T13:58:39Z", "2017-04-27T13:58:39Z");
            dt.Rows.Add(2, "2017-07-27T13:58:39Z", "2017-03-27T13:58:39Z");
            dt.Rows.Add(3, "2017-08-27T13:58:39Z", "2017-03-27T13:58:39Z");
            dt.Rows.Add(4, "2017-09-27T13:58:39Z", "2017-03-27T13:58:39Z");
            dt.Rows.Add(5, "2017-10-27T13:58:39Z", "2017-03-27T13:58:39Z");
     
            
            string fromDate = string.Empty;
            string toDate = string.Empty;
            //Looping data to get fromdate and todate value from each row
            foreach (DataRow dr in dt.Rows)
            {
                fromDate = dr[1].ToString();
                toDate = dr[2].ToString();
                DateTime dtFromDate = Convert.ToDateTime(fromDate);
                DateTime dtToDate = Convert.ToDateTime(toDate);
                //Subtract startTimeDt from endTimeDt and get toatal seconds
                var diffInSeconds = (dtFromDate - dtToDate).TotalSeconds;
            }
