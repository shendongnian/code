            //Datagrid Column collection in Viewmodel
            private ObservableCollection<DataGridColumn> dataGridColumns;
            public ObservableCollection<DataGridColumn> DataGridColumns
            {
                get
                {
                    return dataGridColumns;
                }
                set
                {
                    dataGridColumns = value;
                    OnPropertyChanged();
                }
            }
    
    
