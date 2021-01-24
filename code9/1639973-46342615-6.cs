    string sBarcode = myReader.GetString(0);
    string sName = myReader.GetString(1);
    var sDate = myReader.GetDateTime(2);
    string sQuantity = myReader.GetInt32(3).ToString();
    string sPrice = myReader.GetInt32(4).ToString();
