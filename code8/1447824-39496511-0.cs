    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);
      foreach (DataGridViewRow row in dataGridView.Rows)
      {
        for (var i = 0; i < row.Cells.Count; i++)
        {
          Console.WriteLine(row.Cells[i].Value);
          if (row.Cells[i].Value as string == "OK")
          {
            row.Cells[i].Style.BackColor = Color.Red;
            Console.WriteLine("IF WAS TRUE");
          }
        }
      }
    }
