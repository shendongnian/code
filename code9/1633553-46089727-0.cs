    private void btnAdd_Click(object sender, EventArgs e)
            {
                int quantity;
                int price;
                int barcodes;
                string name;
                DateTime date;
    
                name = tbxName.Text;
                date = Convert.ToDateTime(tbxDate.Text);
                barcodes = Convert.ToInt32(tbxBarcode.Text);
                quantity = Convert.ToInt32(tbxQuantity.Text);
                price = Convert.ToInt32(tbxPrice.Text);
                con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;     AttachDbFilename = \"C:\\Users\\hannes.corbett\\Desktop\\Barcode     Scanning\\Barcode Scanning\\BarcodeDB.mdf\"; Integrated Security = True");
                con.Open();
            cmd = new SqlCommand("INSERT INTO Products (Barcodes, Name, EDate, Quantity, Price) VALUES (@barcodes,@name,@date,@quantity,@price)", con);
                cmd.Parameters.AddWithValue("@barcodes",barcodes);
                cmd.Parameters.AddWithValue("@name", names);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@quantity",quantity);
                cmd.Parameters.AddWithValue("@price",price);
                cmd.ExecuteNonQuery();
                con.Close();
    
                tbxBarcode.Text = String.Empty;
                tbxName.Text = String.Empty;
                tbxDate.Text = String.Empty;
                tbxQuantity.Text = String.Empty;
                tbxPrice.Text = String.Empty;
            }
