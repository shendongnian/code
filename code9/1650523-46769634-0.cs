    private void btnAdd_Click(object sender, EventArgs e)
    {
       string constring = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
                          Directory.GetCurrentDirectory().ToString() + "\\BarcodeDB.mdf;Integrated Security=True";
       string query =
          "INSERT INTO Products (Barcodes, Name, EDate, Quantity, Price) VALUES (@barcodeValue, @nameValue, @dateValue, @quantityValue, @priceValue) ;";
       SqlConnection conDataBase = new SqlConnection(constring);
       SqlCommand cmdDataBase = new SqlCommand(query, conDataBase);
    
       // Add the parameters to the command, setting the values as needed. Guessing at value types here.
       // Note that with strings you will need to define the length of the column in the DB in the assignment
       cmdDataBase.Parameters.Add("barcodeValue", SqlDbType.NVarChar, 255).Value = this.tbxBar.Text;
       cmdDataBase.Parameters.Add("nameValue", SqlDbType.NVarChar, 255).Value = this.tbxName.Text;
       cmdDataBase.Parameters.Add("dateValue", SqlDbType.Date).Value = this.dateDate.Text;
       cmdDataBase.Parameters.Add("quantityValue", SqlDbType.Int).Value = this.tbxQua.Text;
       cmdDataBase.Parameters.Add("priceValue", SqlDbType.Decimal).Value = this.tbxPrice.Text;
    
       SqlDataReader myReader;
       try
       {
          conDataBase.Open();
          myReader = cmdDataBase.ExecuteReader();
          while (myReader.Read())
          {
          }
    
          Fillcombo();
       }
    
       catch (Exception ex)
       {
          MessageBox.Show(ex.Message);
       }
    
       conDataBase.Close();
    }
