         public void AddDataTableRow(Object row)
                {
                    
                    dt.Rows.Add(row);        
                   
                }
        
                public void Toevoegen1_Click(object sender, EventArgs e)
                {
                    Toevoegen tv = new Toevoegen();
                    tv.ShowDialog();
                    AddDataTableRow(tv.Row);
                }
