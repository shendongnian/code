    private void grdEmp_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.Column.Header as string == "empDptID")
        {
            try
            {
                DataGridComboBoxColumn col = new DataGridComboBoxColumn();
                col.Header = "Department";
                // This actually works
                col.ItemsSource = dtDpt.DefaultView;
                col.SelectedValueBinding = new Binding("empDptID");
                col.SelectedValuePath = "dptID";
                col.DisplayMemberPath = "dptName";
                // Replace the auto-generated column with the new one.
                e.Column = col;
            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show(x.Message);
            }
        }
        else if ((e.Column.Header as string == "empID"))
            e.Column.Header = "ID";
        else if ((e.Column.Header as string == "empName"))
            e.Column.Header = "Name";
    }
