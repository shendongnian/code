                foreach (GridViewRow gr in GridView1.Rows)
                {
                    int id = Convert.ToInt32(GridView1.Rows[gr.RowIndex].Cells[0].Text);
                    string source = GridView1.Rows[gr.RowIndex].Cells[1].Text;
                    string destination = ((DropDownList)gr.FindControl("DropDownList1")).SelectedItem.Value;
                 
                    
                    InsertDynamicColumn(source, destination);
                }
