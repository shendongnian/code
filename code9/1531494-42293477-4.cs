     public void CreatGraph()
        {
            var raw_txt = System.IO.File.ReadAllLines(@"D:\\GraphData.csv");
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("x_axis");
            dt.Columns.Add("y_axis");
            DataTable myData = raw_txt.Skip(1)
                      .Select(x =>
                      {
                          var row = dt.NewRow();
                          row.SetField<string>("x_axis", x.Split(',')[7]);
                          row.SetField<string>("y_axis", x.Split(',')[8]);
                          return row;
                      }).CopyToDataTable();
            chart1.Series.Add("test");
            chart1.Series["test"].XValueMember = "x_axis";
            chart1.Series["test"].YValueMembers = "y_axis";
            chart1.DataSource = myData;
            chart1.DataBind();
        }
