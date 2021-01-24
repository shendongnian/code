        DataTable table = new DataTable();
        table.Columns.Add("File Name");
        table.Columns.Add("Sequence");
        for (int i = 0; i < files.Length; i++)
        {
            FileInfo file = new FileInfo(files[i]);
            DataRow r = table.AddNewRow();
            r["File Name"] = file.Name;
            r["Sequence"] = "OtherString";
            table.Rows.Add(r);
        }
        dataGridView1.DataSource = table;
