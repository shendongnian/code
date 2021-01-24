            int i;
            i = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[i].Cells[0].Value = Nametb.Text;
            dataGridView1.Rows[i].Cells[1].Value = Locationtb.Text;
            dataGridView1.Rows[i].Cells[2].Value = Infotb.Text;
            dataGridView1.Rows[i].Cells[3].Value = dayvisittb.Text;
            database1.WriteXml("Database.xml");
