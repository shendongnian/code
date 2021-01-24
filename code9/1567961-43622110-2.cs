    SqlCommand checkSuite = new SqlCommand("SELECT tablenum, tablestatusint FROM tablesstatustbl", cn);
    SqlDataReader readSuite = checkSuite.ExecuteReader();
    while (readSuite.Read())
    {
      int status = Convert.ToInt32(readSuite["tblstatusint"]);
      if (status == 1)
      {
        // I have separated the dictionary access and image assignment into two lines for readability
        int buttonNum = ConvertToInt32(readSuite["tableNum"]);
        btnList[buttonNum].Image = My_Café_Manger.Properties.Resources.tablesbusy;
      }
    }
