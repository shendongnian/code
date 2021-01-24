    for (int i = 0; i < productsDataGridView.Rows.Count; i++)
            {
                 if(productsDataGridView.Rows[i].Cells[6] !=null && productsDataGridView.Rows[i].Cells[6].Value != null)
                 {
                    total +=     int.Parse(productsDataGridView.Rows[i].Cells[6].Value.ToString());
                 }
            }
