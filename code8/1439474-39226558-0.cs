    var lines = new List<string>();
    var headers = grid.Columns.Cast<DataGridViewColumn>()
                                .Where(c => c.Visible).Select(c => c.HeaderText);
    lines.Add(string.Join("\t", headers));
    var rows = grid.Rows.Cast<DataGridViewRow>()
                            .Select(r => string.Join("\t", r.Cells.Cast<DataGridViewCell>()
                            .Where(c => c.Visible).Select(c => c.FormattedValue)));
    lines.AddRange(rows);
    var text = string.Join(Environment.NewLine, lines);
