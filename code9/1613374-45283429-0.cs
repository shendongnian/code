    // if the DataGridView is the only control, you can remove all the controls on the form
    // f.Controls.Clear();
    
    // or you can remove all the DataGridView controls if it is the only Datagridview control
    f.Controls.OfType<DataGridView>().ToList().ForEach( x => f.Controls.Remove( x ) );
    this.Controls.Add(my_datagridview);
