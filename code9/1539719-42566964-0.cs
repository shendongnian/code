    var columns = new int[] { 0, 2 }; //an array of desired column indexes
    var rows = dgv.Rows.Cast<DataGridViewRow>()
                  .Select(r => r.Cells.Cast<DataGridViewCell>()
                                .Where(c => columns.Contains(c.ColumnIndex))
                                .Select(c => string.Format("{0}", c.Value)));
    var lines = rows.Select(x => string.Join(";", x)).ToArray();
    System.IO.File.WriteAllLines(@"d:\file.txt", lines);
