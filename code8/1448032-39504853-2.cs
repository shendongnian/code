    DataTable dtDataSource = new DataTable();
            string[] fileContent = File.ReadAllLines(@"Complete Path Of File");
            if (fileContent.Count() > 0)
            {
                //Create data table columns dynamically
                string[] columns = fileContent[0].Split(',');
                
                for (int i = 0; i < columns.Count(); i++)
                {
                    dtDataSource.Columns.Add(columns[i]);
                }
                //Add row data dynamically
                for (int i = 1; i < fileContent.Count(); i++)
                {
                    string[] rowData = fileContent[i].Split(',');
                    dtDataSource.Rows.Add(rowData);
                }
                if (dtDataSource != null)
                {
                    //dataGridView1 = new DataGridView();
                    dataGridView1.DataSource = dtDataSource;
                }
            }
