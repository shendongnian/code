    while(myReader.Read())
    {
                    string sBarcode = myReader["Barcodes"].ToString();
                    string sName = myReader["Name"].ToString();
                    var sDate = myReader["EDate"];
                    string sQuantity = myReader["Quantity"].ToString();
                    string sPrice = myReader["Price"].ToString();
                    tbxBar.Text = sBarcode;
                    tbxName.Text = sName;
                    sDate = dateDate.Value;
                    tbxPrice.Text = sPrice;
                    tbxQua.Text = sQuantity;
    }
