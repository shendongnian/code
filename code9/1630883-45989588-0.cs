     var li = new List<string>()
            {
                "1111", "3333.0", "1111.00", "9999.4",
            };
    
            var newLi = new List<string>();
    
            var rx1 = new Regex(@"\.\d$");
            var rx2 = new Regex(@"\.\d\d$");
    
            foreach (var item in li)
            {
                if (rx1.IsMatch(item))
                    newLi.Add(item + "0");
                else if (rx2.IsMatch(item))
                    newLi.Add(item);
                else
                    newLi.Add(item + ".00");
            }
    
            //1111.00
            //3333.00
            //1111.00
            //9999.40
