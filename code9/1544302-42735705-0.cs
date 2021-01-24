    string str = "0=Child|13=Teen|18=Adult";
                List<string> seplist = str.Split('|').ToList();
                int Age = 14;
                string Maturity = string.Empty;
                foreach (var item in seplist)
                {
                    var part = item.Split('=');
                    if (int.Parse(part.First()) <= Age)
                        Maturity = part.Last();
                    else
                    {
                        if (int.Parse(part.First()) > Age)
                            break;
                    }
                }
                Console.WriteLine(Maturity);
                Console.ReadLine();
