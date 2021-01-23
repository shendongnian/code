    dgv1.Columns.Cast<DataGridViewColumn>()
        .ToList().ForEach(c =>
        {
            var values = dgv1.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow)
                .Select(r=>r.Cells[c.Index].Value).ToList();
            if (!values.Contains("1")) //your custom criteria
                dgv1.Columns.Remove(c);
        });
