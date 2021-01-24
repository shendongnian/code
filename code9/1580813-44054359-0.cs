    private void LoadGrid()
    {
        int row = 0;
        string line;
        string[] strArray = new string[6];
        dataGridView1.Rows.Clear();
        dataGridView1.ColumnCount = 7;
        dataGridView1.Columns[0].Name = "Nugget ID";
        dataGridView1.Columns[1].Name = "Nugget Name";
        dataGridView1.Columns[2].Name = "Nugget Description";
        dataGridView1.Columns[3].Name = "Nugget Ingredient";
        dataGridView1.Columns[4].Name = "Nugget Stock";
        dataGridView1.Columns[5].Name = "Nugget Price";
        FileStream F = new FileStream("Nugget.txt", FileMode.Open, FileAccess.Read);
        StreamReader R = new StreamReader(F);
        while ((line = R.ReadLine()) != null)
        {
            strArray = line.Split(new string[] { "#" }, StringSplitOptions.None);
               
            dataGridView1.Rows.Add();
            String[] s = line.Split('#');
            for (int i = 0; i <= s.Count() - 1; i++)
            {
                dataGridView1[i, row].Value = s[i];
            }
        }
        R.Close();
        F.Close();
    }
