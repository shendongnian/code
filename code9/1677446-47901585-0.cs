    string item = string.Empty;
    int quantity = 0;
    
    for (int i = 0; i <= LBItemName.Items.Count - 1; i++)
    {
        var item = Convert.ToString(LBItemName.Items[i]);
        var quantity = Convert.ToInt32(LBItemQuantity.Items[j]);
        MySqlCommand tryCommand = new MySqlCommand($"UPDATE QuizonVet.Product SET numberofstocks=(numberofstocks-{quantity}) where productname='{item}'", myConnection);
        myReader = tryCommand.ExecuteReader();
    }
           
    myReader.Close();
