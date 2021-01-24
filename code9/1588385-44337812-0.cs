        private void turmasDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
               if (turmasDataGridView.CurrentCell.EditType == typeof(DataGridViewTextBoxEditingControl))
               {
                   turmasDataGridView.BeginEdit(false);
                        ((TextBox)turmasDataGridView.EditingControl).SelectionStart = 0;
  
                }
        }
