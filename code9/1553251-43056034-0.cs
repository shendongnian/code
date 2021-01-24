        private void AddDataToDGV()
        {
            DataTable dt = new DataTable();
            //create some columns for the datatable
            DataColumn dc = new DataColumn("ItemName");
            DataColumn dc2 = new DataColumn("ItemValue");
            DataColumn dc3 = new DataColumn("Blah");
            DataColumn dc4 = new DataColumn("Bleh");
            //add the columns to the datatable
            dt.Columns.Add(dc);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            //create 5 rows of irrelevant information
            //this is the actual answer to your question
            for (int i = 0; i < 5; i++)
            {
                DataRow dr = dt.NewRow();//create a new row based on the existing "row model"
                dr["ItemName"] = "Item" + i + "Name";
                dr["ItemValue"] = "Item" + i + "Value";
                dr["Blah"] = "Item" + i + "Blah";
                dr["Bleh"] = "Item" + i + "Bleh";
                dt.Rows.Add(dr);//add the row to the DataTable
            }
        }
