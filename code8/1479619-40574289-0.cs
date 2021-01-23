    //This event is just a dummy and doesn't exists this way
    private void grid_click(object sender, EventArgs e)
    {
       //DataTable access
       var row = gridview.GetFocusedRow() as DataRowView;
       MessageBox.Show(Convert.ToString(row["Price"]);
    
       //List access
       var lineaTicket = gridView.GetFocusedRow() as LineaTicket; //You directly see it's a ticket here
       MessageBox.Show(lineaTicket.Price); //You don't need conversion
    }
