    private void Form5_Load(object sender, EventArgs e)
            {
                var lstTemp = new List<test>();
                for (int i = 0; i < 10; i++)
                    lstTemp.Add(new test() { Name = "Test", No = i, Desc = "Desc " + i, Desc1 = "Desc1 " + i });
    
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("No", "Number");
                dataGridView1.Columns.Add("Desc", "Description1");
                dataGridView1.Columns.Add("Desc1", "Description2");
    
                foreach (var temp in lstTemp)
                {
                    DataGridViewRow row = (DataGridViewRow) dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = temp.Name;
                    row.Cells[1].Value = temp.No;
                    row.Cells[2].Value = temp.Desc;
                    row.Cells[3].Value = temp.Desc1;
                    dataGridView1.Rows.Add(row);
                }
            }
    
            public class test
            {
                public string Name { get; set; }
                public int No { get; set; }
                public string Desc { get; set; }
                public string Desc1 { get; set; }
            }
