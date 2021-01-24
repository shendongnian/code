            int manufacturerid = 32;
            var query = @"Select * from POManage po
                Where po.VendorID = @manufacturerid
                and CONVERT(DATE, po.order_date) between @StartDate and @EndDate 
                order by PONumber asc";
            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now;
            var connectionString = "your connection string";
            var dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@manufacturerid", manufacturerid);
                    adapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate);
                    adapter.Fill(dataTable);
                }
            }
