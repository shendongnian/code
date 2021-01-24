            const string columnNameId = "Id";
            var dtblLeft = new DataTable();
            dtblLeft.Columns.Add(new DataColumn(columnNameId, typeof(int)));
            dtblLeft.Columns.Add(new DataColumn("Name", typeof(string)));
            var dr1 = dtblLeft.NewRow();
            dr1[columnNameId] = 1;
            dr1["Name"] = "item1";
            dtblLeft.Rows.Add(dr1);
            var dr2 = dtblLeft.NewRow();
            dr2[columnNameId] = 1;
            dr2["Name"] = "item2";
            dtblLeft.Rows.Add(dr2);
            var dr3 = dtblLeft.NewRow();
            dr3[columnNameId] = 3;
            dr3["Name"] = "item3";
            dtblLeft.Rows.Add(dr3);
            
            var dtblRight = new DataTable();
            dtblRight.Columns.Add(new DataColumn(columnNameId, typeof(int)));
            dtblRight.Columns.Add(new DataColumn("Stock", typeof(string)));
            var dr4 = dtblRight.NewRow();
            dr4[columnNameId] = 1;
            dr4["Stock"] = "blabla";
            dtblRight.Rows.Add(dr4);
            var dr5 = dtblRight.NewRow();
            dr5[columnNameId] = 3;
            dr5["Stock"] = "bla2";
            dtblRight.Rows.Add(dr5);
            
            var dtblResult = new DataTable();
            dtblResult.Columns.Add(new DataColumn(columnNameId, typeof(int)));
            dtblResult.Columns.Add(new DataColumn("Name", typeof(string)));
            dtblResult.Columns.Add(new DataColumn("Stock", typeof(string)));
            
            var result = from rowLeft in dtblLeft.AsEnumerable()
                join rowRight in dtblRight.AsEnumerable() on rowLeft[columnNameId] equals rowRight[columnNameId] into gj
                from subRight in gj.DefaultIfEmpty()
                select dtblResult.NewRow().ItemArray = new[]
                {
                    rowLeft[columnNameId],
                    rowLeft["Name"],
                    subRight?["Stock"] ?? ""
                };
            foreach (var dataRow in result)
            {
                dtblResult.Rows.Add(dataRow);
            }
