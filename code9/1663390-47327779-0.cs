    private static void ParseTimeSpan(string intervalStr)
    {
      // Write the first part of the output line.
      Console.Write( "{0,20}   ", intervalStr );
      // Parse the parameter, and then convert it back to a string.
      TimeSpan intervalVal; 
      if (TimeSpan.TryParse(intervalStr, out intervalVal)) 
      {
         string intervalToStr = intervalVal.ToString();
         // Pad the end of the TimeSpan string with spaces if it 
         // does not contain milliseconds.
         int pIndex = intervalToStr.IndexOf(':');
         pIndex = intervalToStr.IndexOf('.', pIndex);
         if (pIndex < 0)
            intervalToStr += "        ";
         Console.WriteLine("{0,21}", intervalToStr);
         // Handle failure of TryParse method.
      }
      else
      {
         Console.WriteLine("Parse operation failed.");
      }
    } 
