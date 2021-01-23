    private void dataGrid_Table_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                // Make all columns nullable
                ((DataGridBoundColumn)e.Column).Binding.TargetNullValue = "NULL";
            }
