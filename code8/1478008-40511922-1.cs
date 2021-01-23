    private void Form1_Load(object sender, EventArgs e)
    {
        //Opens csv file and splits the data seperated by a ',' into cells
        using (StreamReader file = new StreamReader(@"..."))
        {
            string[] columnnames = file.ReadLine().Split(',');
            DataTable dt = new DataTable();
            foreach (string c in columnnames)
            {
                dt.Columns.Add(c);
            }
            string newline;
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                dt.Rows.Add(dr);
            }
            
            dataGridView1.DataSource = dt;
        }
    }
    private void saveToolStripButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Data Saved.");
        using (StreamWriter fileWriter = new StreamWriter(@"..."))
        {
            string columnHeaderText = "";
            //Collecting DataGridView Column Header Text
            int countColumn = dataGridView1.ColumnCount - 1;
            if (countColumn >= 0)
            {
                columnHeaderText = dataGridView1.Columns[0].HeaderText;
            }
            for (int i = 1; i <= countColumn; i++)
            {
                columnHeaderText = columnHeaderText + ',' + dataGridView1.Columns[i].HeaderText;
            }
            //Writing Column Header Text in File
            fileWriter.WriteLine(columnHeaderText);
            //Collecting Data Rows
            foreach (DataGridViewRow dataRowObject in dataGridView1.Rows)
            {
                //Checking for New Row in DataGridView 
                if (!dataRowObject.IsNewRow)
                {
                    string dataFromGrid = "";
                    dataFromGrid = dataRowObject.Cells[0].Value.ToString();
                    for (int i = 1; i <= countColumn; i++)
                    {
                        dataFromGrid = dataFromGrid + ',' + dataRowObject.Cells[i].Value.ToString();
                    }
                    //Writing Data Rows in File         
                    fileWriter.WriteLine(dataFromGrid);
                }
            }
        }
    }
