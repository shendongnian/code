    var value = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
    
    var query = context.mySoftWare
        .Where(s => s.Software.Contains(value))
        .Select(r => new { r.SID, r.Software, r.Vendor, r.Version });
    dataGridView1.DataSource = query.ToList();
