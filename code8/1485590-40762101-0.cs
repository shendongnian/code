     private void AddColumns()
        {
            
            var col1 = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewCheckBoxColumn();
            var col3 = new DataGridViewCheckBoxColumn();
    
            col1.HeaderText = "YourHeaderText";
            col1.Name = "ID";
    
            col2.HeaderText = "YourHeaderText";
            col2.Name = "UserID";
    
            col3.HeaderText = "YourHeaderText";
            col3.Name = "Socities";
    
            dgwUser.Columns.AddRange(new DataGridViewColumn[] {col1,col2,col3});
        }
 
       ...
      _bs.DataSource = ListSociety;
       dgwUser.DataSource = _bs;
       AddColumns();
       dgwUser.Refresh();
       _bs.ResetBindings(false);   
       ...
