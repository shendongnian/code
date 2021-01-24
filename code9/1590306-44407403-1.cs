    void fillDataGrid()    
    {
        list1.Add(new classList { p1 = "1", p2 = "2", p3 = "3", p4 = "4" });
        list1.Add(new classList { p1 = "5", p2 = "6", p3 = "7", p4 = "8" });
        list2.Add(new classList { p1 = "9", p2 = "10", p3 = "11", p4 = "12" });
        list2.Add(new classList { p1 = "13", p2 = "14", p3 = "15", p4 = "16" });
        dataGridView1.ColumnCount = 8;
        for (int i = 0; i < list1.Count; i++)
        {
            this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[i].Cells[0].Value = list1[i].p1;
            this.dataGridView1.Rows[i].Cells[1].Value = list1[i].p2;
            this.dataGridView1.Rows[i].Cells[2].Value = list1[i].p3;
            this.dataGridView1.Rows[i].Cells[3].Value = list1[i].p4;            
        }
        for (int i = 0; i < list2.Count; i++)
        {
            this.dataGridView1.Rows[i].Cells[4].Value = list2[i].p1;
            this.dataGridView1.Rows[i].Cells[5].Value = list2[i].p2;
            this.dataGridView1.Rows[i].Cells[6].Value = list2[i].p3;
            this.dataGridView1.Rows[i].Cells[7].Value = list2[i].p4;
        }
    }
