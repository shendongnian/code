    private void setDataSource(){
       //added column with image before set datasource
       if (grid.Columns["Del"] == null) {
                        var col = new DataGridViewImageColumn();
                        col.HeaderText = "";
                        col.Name = "Del";
                        col.Image = TerminalControleDeVendas.Properties.Resources.trash;
                        grid.Columns.Add(col);
                    }
       grid.DataSource = ivDAO.findAllItemVenda(venda);
       grid.ClearSelection();
       defineGrid();
    }  
    
    
    private void defineGrid() {
                //header 
                grid.Columns["produto"].HeaderText = "Produto";
                grid.Columns["valorUn"].HeaderText = "Unit.R$";
                grid.Columns["quantidade"].HeaderText = "Qtd.";
                grid.Columns["total"].HeaderText = "Total R$";
    
                //hide
                grid.Columns["id"].Visible = false;
                grid.Columns["venda"].Visible = false;
    
                //width
                grid.Columns["Del"].Width = 30;
                grid.Columns["produto"].Width = 220;
                grid.Columns["valorUn"].Width = 80;
                grid.Columns["quantidade"].Width = 50;
                grid.Columns["total"].Width = 80;
    
                //align
                grid.Columns["valorUn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grid.Columns["quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grid.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            
            }
