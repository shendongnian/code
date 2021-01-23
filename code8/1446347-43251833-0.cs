    foreach (var worksheetPart in spreadsheet.WorkbookPart.WorksheetParts)
         {
             //Call the method to convert the Password string "MyPasswordfor sheet" to hexbinary type
             string hexConvertedPassword =  HexPasswordConversion("MyPasswordfor sheet");
    //passing the Converted password to sheet protection
              SheetProtection sheetProt = new SheetProtection() { Sheet = true, Objects = true, Scenarios = true, Password = hexConvertedPassword };
              worksheetPart.Worksheet.InsertAfter(sheetProt,worksheetPart.Worksheet.Descendants<SheetData>().LastOrDefault());
    worksheetPart.Worksheet.Save();
         }
    
    
    /* This method will convert the string password to hexabinary value */
     protected string HexPasswordConversion(string password)
            {
                byte[] passwordCharacters = System.Text.Encoding.ASCII.GetBytes(password);
                int hash = 0;
                if (passwordCharacters.Length > 0)
                {
                    int charIndex = passwordCharacters.Length;
    
                    while (charIndex-- > 0)
                    {
                        hash = ((hash >> 14) & 0x01) | ((hash << 1) & 0x7fff);
                        hash ^= passwordCharacters[charIndex];
                    }
                    // Main difference from spec, also hash with charcount
                    hash = ((hash >> 14) & 0x01) | ((hash << 1) & 0x7fff);
                    hash ^= passwordCharacters.Length;
                    hash ^= (0x8000 | ('N' << 8) | 'K');
                }
    
                return Convert.ToString(hash, 16).ToUpperInvariant();
            }
