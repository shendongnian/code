    carmodel.Items.Clear();
    while (myReader.Read())
    {
    
        //  string namethestore = myReader.IsDBNull(model)
        //   ? string.Empty
        //  : myReader.GetString("model");
    
        //   this.carmodel.Text = namethestore;
    
        //  string namethestore1 = myReader.IsDBNull(model)
        //  ? string.Empty
        // : myReader.GetString("parts");
    
        ///  this.carpart.Text = namethestore1;
        carmodel.Items.Add(myReader["Model"].ToString());
    
        carpart.Items.Add(myReader["Part"].ToString());
    
    }
