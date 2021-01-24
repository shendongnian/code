                    if (this.MyQueryStatus.Equals(QueryStatus.Succeeded))
                    {
                        #region IF Succeeded
                        #region Create Results DataTable
                        DataTable resultsTable = new DataTable("Results");
                        resultsTable.Columns.Add("Id");
                        resultsTable.Columns.Add("FullName");
                        resultsTable.Columns.Add("Foreground");
                        resultsTable.Columns.Add("Blink");
                        resultsTable.Columns.Add("Background");
                        resultsTable.Columns.Add("TypeDesc");
                        resultsTable.Columns.Add("MemoryUsage");
                        #endregion Create Results DataTable
                        foreach (var row in this.MyQueryResult.Rows)
                        {
                            #region ForEach Row
                            DataRow newRow = resultsTable.NewRow();
                            newRow["Id"] = row.Data[0].ToString();
                            newRow["FullName"] = row.Data[1].ToString();
                            newRow["Foreground"] = row.Data[2].ToString();
                            newRow["Blink"] = row.Data[3].ToString();
                            newRow["Background"] = row.Data[4].ToString();
                            newRow["TypeDesc"] = row.Data[5].ToString();
                            newRow["MemoryUsage"] = row.Data[6].ToString();
                            resultsTable.Rows.Add(newRow);
                            #endregion ForEach Row
                        }
                        dataGridViewResults.DataSource = resultsTable;
                        tabControlMain.SelectedTab = tabControlMain.TabPages["tabPageResults"];
                        #endregion IF Succeeded
                    }
