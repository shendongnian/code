    bool isRightClick = false;
    private Employee selectedDataGridRow;
    public Employee SelectedDataGridRow
    {
        get
        {
            return selectedDataGridRow;
        }
        set
        {
            selectedDataGridRow = value;                
            NotifyPropertyChanged("SelectedDataGridRow");
            if (isRightClick)
            {
                <do your work here>
                isRightClick = false;
            }
        }
    }
    private void dgDatagrid_PreviewMouseRightButtonDown(object sender, 
                 System.Windows.Input.MouseButtonEventArgs e)
        {
            isRightClick = true;
        }
