    CloseEditMode() 
    { 
       gridRubrica.AllowEdit = InheritableBoolean.False; 
       gridRubrica.AllowEdit = InheritableBoolean.True; 
    } 
    
    private void gridRubrica_CellValueUpdated(object sender, ColumnActionEventArgs e) 
    { 
       if (e.Column.Key.Equals("Selected")) { CloseEditMode(); } 
    } 
