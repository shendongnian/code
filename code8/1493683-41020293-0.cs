    public string Encode(string input, int initialOffset = 0x20)
    {
         string result = "";
         foreach(var c in input)
         {
              result += (char)(c + (initialOffset --));
         }
         return result;
    }
