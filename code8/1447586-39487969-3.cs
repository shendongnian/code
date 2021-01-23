        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = 0;            
            id = Convert.ToInt32(lblId.Text);               
            foreach (var dgr in gridViewCompanies.Rows)
            {
                if (dgr.Cells[0].Value.Equals(tbl.ID))
                {
                    dgr.IsSelected = true;
                    dgr.Cells[0].IsSelected = true;
                      
                    this.radGridView.TableElement.VScrollBar.Value = dgr.Index;
                    break;
                }
            }
         }
