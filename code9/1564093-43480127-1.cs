     // To show the selected items
     private void btnPrueba_Click(object sender, RoutedEventArgs e)
     {
         var selectedItems = MaterialesVM.Where(x => x.IsChecked);
         foreach (var item in selectedItems)
         {
             MessageBox.Show(((MaterialesCL)item).DescCompuesta);
         }
     }
