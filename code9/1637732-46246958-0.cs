    public static string ConvertHex(String hexString)
    {
        try
        {
            //DECLARE A VARIABLE TO RETURN
            string ascii = string.Empty;
            //SPLIT THE HEX STRING BASED ON SPACE (ONE SPACE BETWEEN TWO NUMBERS)
            string[] hexSplit = hexString.Split(' ');
            //LOOP THROUGH THE EACH HEX SPLIT
            foreach (String hex in hexSplit)
            {
                // CONVERT THE NUMBER TO BASE 16
                int value = Convert.ToInt32(hex, 16);
                // GET THE RESPECTIVE CHARACTER
                string stringValue = Char.ConvertFromUtf32(value);
                char charValue = (char)value;
                //APPEND THE STRING
                ascii += charValue;
            }
            //RETURN THE STRING
            return ascii;
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        return string.Empty;
    }
