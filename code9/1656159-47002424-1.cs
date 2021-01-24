    StringBuilder sb = new StringBuilder();
    char symbol = "A";
    foreach (byte b in Encoding.Unicode.GetBytes(symbol.ToString()))
    {
         sb.Append(Convert.ToString(b, 2));
    }
    string bits = sb.ToString();
    List<bool> myBuffer= ...
    
    for (int i = 0; i < bits .Length; i++)
    {
         if (bits [i] == '0')
         {
              myBuffer.Add(false);
         }
         else if (bits [i] == '1')
         {
             myBuffer.Add(true);
         }
    }
