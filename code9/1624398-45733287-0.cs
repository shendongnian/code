            DataTable dt2 = new DataTable();
            var showResults = dt2.Rows.Cast<DataRow>().Join(dt2.Rows.Cast<DataRow>(), a => a.Field<string>("txtItemNumber"), b => b.Field<string>("txtItemA"), (a, b) => new
            {
                newseries = a.Field<string>("newseries"),
                series = a.Field<string>("series")
            });
            ListView1.DataSource = showResults.ToArray();
            ListView1.DataBind();
