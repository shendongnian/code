                if (collListItem.Count != 0)
                {
                    var dtCoaching = new DataTable();
                    dtCoaching.Columns.AddRange(new[]
                    {
                        new DataColumn("Call Type"),  new DataColumn("Count")
                    });
                    foreach (var oListItem in collListItem)
                    {
                        dtCoaching.Rows.Add(oListItem["Call_x0020_Type"]);
                    }
                    var result = from row in dtCoaching.AsEnumerable()
                                 group row by row.Field<string>("Call Type") into grp
                                 select new
                                 {
                                     CallType = grp.Key,
                                     CallCount = grp.Count()
                                 };
                    DataTable dtCoachingClone = new DataTable();
                    dtCoachingClone = dtCoaching.Clone();
                    foreach (var item in result)
                    {
                        DataRow newRow = dtCoachingClone.NewRow();
                        newRow["Call Type"] = item.CallType;
                        newRow["Count"] = item.CallCount;
                        dtCoachingClone.Rows.Add(newRow);
                    }
                    if (dataGridViewCallType != null)
                    {
                        dataGridViewCallType.DataSource = dtCoachingClone;
                    }
                    return;
                }
