    var columns = new int[] { 0, 2 }; /* desired column indexes*/
    var rows = dgv.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow)
        .Select(r => columns.Select(c => string.Format("{0}", r.Cells[c].Value)));
    var headers = string.Join(";", columns.Select(i => dgv.Columns[i].HeaderText));
    var lines = rows.Select(x => string.Join(";", x)).ToList();
    lines.Insert(0, headers);
    System.IO.File.WriteAllLines(@"d:\file.txt", lines);
