      static void Main(string[] args)
      {
          List<string> converted = new List<string>();
          while (true)   // forever
          {
              // Read next line
              string text = Console.ReadLine();
              if (text == null)
              {
                  break;    // no more lines available
              }
              // Convert to capitals
              TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
              string convertedText = ti.ToTitleCase(text).Replace(" ", "");
              converted.Add(convertedText);
              Console.WriteLine(convertedText);
          }
      }
