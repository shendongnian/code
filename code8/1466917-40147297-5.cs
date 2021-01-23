    var names = ass_code.Split(';').Select(p => p.Trim()).ToList();
          for (int i = 0; i < gridView1.RowCount; i++)
          {
             string g = gridView1.GetDataRow(i)["code"].ToString().Trim();
             if (names.Contains(g))
                gridView1.SetRowCellValue(i, "Dada", true);
             else
                gridView1.SetRowCellValue(i, "Dada", false);
         }
