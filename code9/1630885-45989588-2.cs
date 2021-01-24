    string MoneyDecimals(string num)
                {
                    var rx1 = new Regex(@"\.\d$");
                    var rx2 = new Regex(@"\.\d\d$");
                    var rx3 = new Regex(@"^\d+$");
        
                    if (rx1.IsMatch(num))
                        return num + "0";
                    else if (rx2.IsMatch(num))
                        return num;
                    else if (rx3.IsMatch(num))
                        return num + ".00";
                    else
                        return num;
                }
