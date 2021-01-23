    private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e) {
                if (this.grid.Columns[e.ColumnIndex].Name == "Del") {
                    DialogResult confirma = MessageBox.Show("Deseja realmente excluir o item ?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirma == DialogResult.Yes) {
                        ItemVenda iv = (ItemVenda)grid.CurrentRow.DataBoundItem;
                        ivDAO.delete(iv);                        
                    }
                }            
            }
