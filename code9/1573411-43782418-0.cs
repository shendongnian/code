     foreach (DataGridViewRow row in  dataGridView1.Rows)
     {
          foreach (var cell in row.Cells)
          {
            DataGridViewLinkCell linkCell = cell as DataGridViewLinkCell;
            if(linkCell != null)
            {
              linkCell.LinkBehavior = LinkBehavior.NeverUnderline;
            }
          }
    }
