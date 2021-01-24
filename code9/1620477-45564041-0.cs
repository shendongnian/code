    private void ProductServicesDataGrid_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                     if(ProductServicesDataGrid.SelectedCells!=null)
                     {
                      // you can use selected rows in a foreach loop however you want                         
                     ProductContextMenu = new ProductContextMenu();
                         foreach (DataGridViewCell cell in ProductServicesDataGrid.SelectedCells)
                          {
                          m.MenuItems.Add(new MenuItem(cell.Value));
                          }
                          ProductContextMenu.Show(ProductServicesDataGrid, e.X, e.Y);
                     }
                    else 
                    {
                     // any cells are selected
                    }
                }
            }
