    string RequiredOutputString = String.Empty;
    foreach (Excel.Range item in range.Cells)
    {
      string text = (string)item.Text;
      if (text == "Good")
      {
        //get address of all Good items 
        string textx = (string)item.Address;
        //change address of Good items to corresponing address in D column
        string textxcorrect = textx.Replace("B", "D");
        //get rid of "$" for address
        var cellAddress = textxcorrect.Replace("$", "");
        //create range for addresses with the new D column addresses
        Excel.Range xlRng = xlWorkSheet.get_Range(cellAddress, Type.Missing);
        foreach (Excel.Range item2 in xlRng)
        {
		  RequiredOutputString += item2.Text.Trim();
        }
      }
    }
    string fileLocation = @"C:\\Users\\npinto\\Desktop\\hopethisworks.txt";
    File.WriteAllText(fileLocation, RequiredOutputString);
