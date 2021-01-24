    StringBuilder sb = new StringBuilder();
    string symbol = "A";
    foreach (byte b in Encoding.Unicode.GetBytes(symbol))
    {
         sb.Append(Convert.ToString(b, 2));
    }
    symbol = sb.ToString();
    List<bool> myBuffer= ...
    
    for (int i = 0; i < symbol.Length; i++)
    {
         if (symbol[i] == '0')
         {
              myBuffer.Add(false);
         }
         else if (symbol[i] == '1')
         {
             myBuffer.Add(true);
         }
    }
