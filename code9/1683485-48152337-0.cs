    string testInput =
       "[section1]\r\n" +
       "param1=value1\r\n" +
       "param2=value2\r\n\r\n" +
       "[section2]\r\n" +
       "parama=valuea";
    
    using (var reader = new System.IO.StringReader(testInput))
    {
       string inputLine;
       while ((inputLine = reader.ReadLine()) != null)
       {
          string[] values = inputLine.Split(new char[] {'='}, 2);
          if (values.Length > 1)
          {
             Console.WriteLine("Value of {0} is {1}", values[0], values[1]);
          }
          else
             Console.WriteLine("\"{0}\" has {1} characters and {2} values on it", inputLine, inputLine.Length, values.Length);       }
    }
