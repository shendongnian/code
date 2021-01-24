            foreach (DataTable datasetTable in dataset.Tables)
            {
                datasetTable.Columns.Add("Value1", typeof(string));
                datasetTable.Columns.Add("Value2", typeof(string));
                datasetTable.Columns.Add("Value3", typeof(string));
                datasetTable.Columns.Add("Value4", typeof(string));
                foreach (DataRow datasetTableRow in datasetTable.Rows)
                {
                    datasetTableRow["Value1"] = command.Parameters["@Value1"].Value;
                    datasetTableRow["Value2"] = command.Parameters["@Value2"].Value;
                    datasetTableRow["Value3"] = command.Parameters["@Value3"].Value;
                    datasetTableRow["Value4"] = command.Parameters["@Value4"].Value;
                }
            }
