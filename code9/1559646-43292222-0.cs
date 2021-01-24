        string text = @" T1 
           {
              data1=3.5
              data2=58%
              data3=FAIL
           }
         
            T2
            {
               data1=7.5
               data2=78%
               data3=PASS
            }";
        string regex = "[ \n\r\t]*([^ \n\r\t{]*)[ \n\r\t]*{[ \n\r\t]*data1=([^ \n\r\t]*)[ \n\r\t]*data2=([^ \n\r\t]*)[ \n\r\t]*data3=([^ \n\r\t]*)[ \n\r\t]*}";
        while(System.Text.RegularExpressions.Regex.IsMatch(text, regex)) {
            var match = System.Text.RegularExpressions.Regex.Match(text, regex);
            Console.WriteLine($"Item name {match.Groups[1].Value}");
            Console.WriteLine($"Data1= {match.Groups[2].Value}");
            Console.WriteLine($"Data2= {match.Groups[3].Value}");
            Console.WriteLine($"Data3= {match.Groups[4].Value}");
            text = text.Substring(match.Groups[0].Value.Length);
        }
