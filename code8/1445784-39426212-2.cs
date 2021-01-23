        var list = dgvNachrichten.Rows.Cast<DataGridViewRow>()
            .Where(x => x.Cells["Datum"].Value != null && x.Cells["Nachricht"].Value != null)
            .Select(x => new Nachrichten_Felder()
            {
                Datum = x.Cells["Datum"].Value.ToString(),
                Nachricht = x.Cells["Datum"].Value.ToString()
            }).ToList();
