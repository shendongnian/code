     var li = new List<string>()
            {
                "1111", "3333.0", "1111.00", "9999.4",
            };
    
            string MoneyDecimals(string num)
            {
                var rx1 = new Regex(@"\.\d$");
                var rx2 = new Regex(@"^\d+$");
    
                if (rx1.IsMatch(num))
                    return num + "0";
                else if (rx2.IsMatch(num))
                    return num + ".00";
                else
                    return num;
            }
    
            foreach (var item in li)
            {
                Console.WriteLine(MoneyDecimals(item));
            }
    
            //1111.00
            //3333.00
            //1111.00
            //9999.40
