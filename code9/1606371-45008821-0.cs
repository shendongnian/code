    DateTime dt = new DateTime();
    dt = DateTime.Now;
    //Convert date time format 20170710041800
    string str = dt.ToString("yyyyMMddhhmmss");           
    //Convert to Long 
    long decValue = Convert.ToInt64(str);
    //Convert to HEX 1245D8F5F7C8
    string hexValue = decValue.ToString("X");
    //Hex To Long again 20170710041800
    long decAgain = Int64.Parse(hexValue, System.Globalization.NumberStyles.HexNumber); 
