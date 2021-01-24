      private void OnLoad(object sender, EventArgs e)
        {
            _listTypeComboBox.DataSource = AllTypesDataSource;          
            _dataGrid.LinkClicked += OnDataGridLinkClicked;
        }
     void OnDataGridLinkClicked(object sender, ColumnActionEventArgs e)
        {
            var dg = (GridEX)sender;
            var wrapper = (SuspiciousListUploadInfoWrapper)dg.CurrentRow.DataRow;
            wrapper.FileOperator.LinkCommand.Execute(wrapper);
        }
