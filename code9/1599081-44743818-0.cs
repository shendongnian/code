    if(dataGridView1.SelectedRows.Length > 0)
        {
            //get all selected rows
            var rows = dataGridView1.SelectedRows;
            if(rows.Length > 0)
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    //get cells in individual columns
                    var cells = rows[i].Cells;
                    if(cells.Length > 0)
                    {
                        //productId in cell 1
                        var productId = cells[0].Value.ToString();
                        //product name in cell 2
                        var productName = cells[1].Value.ToString();
                        wrt.WriteElementString("ItemID",productId);
                        wrt.WriteElementString("ItemName", productName);
                    }
                }
            }
        }
