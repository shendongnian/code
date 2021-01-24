        //using System.Linq;
        private void button1_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.Rows.OfType<DataGridViewRow>()
                .Reverse().Skip(1);//ignore the last empty line
            var dupRos = rows.GroupBy(r => r.Cells["name"].Value.ToString())
            .Where(g => g.Count() > 1)
            .SelectMany(r => r.ToList());
            foreach (var r in dupRos)
                r.DefaultCellStyle.BackColor = Color.Red;
            foreach (var r in rows.Except(dupRos))
                r.DefaultCellStyle.BackColor = Color.White;
        }
