        //Add the row to the table
        Table.Rows.Add(row);
        Button getname = new Button();
        getname.Attributes.Add("idRow", idrow);
        idrow += 1;
        getname.Text = "Reserve";
        getname.Click += new EventHandler(getname_Click);
