    // if the DataGridView is the only control, you can remove all the controls on the form
    // this.Controls.Clear();
    
    // or you can remove all the DataGridView controls if it is the only Datagridview control
    this.Controls.OfType<DataGridView>().ToList().ForEach( x => this.Controls.Remove( x ) );
    this.Controls.Add(my_datagridview);
