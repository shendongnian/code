    string RequiredOutputString = String.Empty;
    foreach (Excel.Range item in range.Cells)
    {
      string text = (string)item.Text;
      if (text == "Good")
      {
        //get address of all Good items 
        string textx = (string)item.Address;
        //change address of Good items to corresponing address in D column
        var cellAddress = textx.Replace("$B", "D");
        // get a reference to cell in column D
        Range xlRng = curWorkSheet.get_Range(cellAddress, Type.Missing);
        // get the cell address in row D cell
        string nextAddr = xlRng.Text;
        // get a reference to the cell point to from Row D
        Range xlRng2 = curWorkSheet.get_Range(nextAddr, Type.Missing);
        // append that cell contents
        RequiredOutputString += xlRng2.Text.Trim();
      }
    }
    string fileLocation = @"C:\\Users\\npinto\\Desktop\\hopethisworks.txt";
    File.WriteAllText(fileLocation, RequiredOutputString);
