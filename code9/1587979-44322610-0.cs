            dataGridView1.Rows.Add("254");
            dataGridView1.Rows.Add("124");
            dataGridView1.Rows.Add("543");
            dataGridView1.Rows.Add("234");
            dataGridView1.Rows.Add("254");
            bool anyDuplicated = dataGridView1.Rows
                .OfType<DataGridViewRow>()
                .Where(x => x.Cells["Column1"].Value != null)
                .Select(x => x.Cells["Column1"].Value.ToString())
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .Any();
