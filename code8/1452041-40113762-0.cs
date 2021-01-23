                    DataTable tbl = new DataTable();
                tbl.Columns.Add("Symbol Name", typeof(string));
                // Add columns
                foreach (InspectorOutput item in listScenarioOutput)
                {
                    foreach (KeyValuePair<string, double> entry in item.ListPrices)
                    {
                        tbl.Columns.Add(entry.Key, typeof(double));
                    }
                    break;
                }
                for (int i = 0; i < listScenarioOutput.Count; i++)
                {
                    DataRow row = tbl.NewRow();
                    row.SetField(0, listScenarioOutput[i].SymbolName);
                    int j = 0;
                    foreach (KeyValuePair<string, double> entry in listScenarioOutput[i].ListPrices)
                    {
                        row.SetField(++j, entry.Value);
                    }
                    tbl.Rows.Add(row);
                }
                gridStockData.ItemsSource = tbl.DefaultView;
