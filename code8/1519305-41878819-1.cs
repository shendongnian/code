      static void Main(string[] args)
      {
          List<string> converted = new List<string>();
          while (true)   // forever
          {
              string text = Console.ReadLine();
              if (text == null)
              {
                  break;    // no more lines available - break out of loop.
              }
              // Convert to capitals
              TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
              string convertedText = ti.ToTitleCase(text).Replace(" ", "");
              converted.Add(convertedText);
          }
          // Now display the converted lines
          foreach (string text in converted)
          {
              Console.WriteLine(text);
          }
      }
