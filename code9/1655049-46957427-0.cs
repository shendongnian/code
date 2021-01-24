    grid.AutoGeneratingColumn += (object sender, DataGridAutoGeneratingColumnEventArgs e) =>
    {
        e.Column.IsReadOnly = true;
        e.Column.CanUserReorder = false;
        e.Column.CanUserResize = false;
        e.Column.CanUserSort = false;
    };
   
