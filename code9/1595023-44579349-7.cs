             Console.WriteLine("About to call Console.ReadLine in a loop.");
            Console.WriteLine("----");
            String s;
            do
            {
                s = Console.ReadLine();
                Regex regex = new Regex("[0-9]");
                Regex regex2 = new Regex("[a-zA-Z]");
                if (regex.IsMatch(s))
                {
                    if (regex.IsMatch(s) && regex2.IsMatch(s))
                    {
                        Console.WriteLine("You entered an combination of number and String = " + s.ToString());
                    }
                    else
                    {
                        int cnt = s.Count(x => x == '.');
                        if (s.Count(x => x == '.') > 1)
                        {
                            Console.WriteLine("Invalid input of number = " + s.ToString());
                        }
                        else if (s.Count(x => x == '.') == 1 && regex.IsMatch(s))
                        {
                            Console.WriteLine("You entered a decimal number = " + s.ToString());
                        }
                        
                        else
                        {
                            char[] str = "!@#$%^&*()',-./:;<=>?@_`{|}~¡¢£¤¥¦§¨©¬®¯°±²³´µ¶¸¹º»¼½¾¿ÀÈËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõöL÷øùúûüýþÿ\"".ToArray();
                            int indexOf = s.IndexOfAny(str);
                            if (indexOf == -1)
                            {
                                
                                Console.WriteLine("You entered a number = " + s.ToString());
                            }
                            else
                            {
                                Console.WriteLine("You entered an combination of number and String = " + s.ToString());
                            }
                        }
                    }
                }
                else
                {
                    if (s.Trim().Length < 1)
                    {
                        Console.WriteLine("Please enter any value.");
                    }
                    else
                    {
                        Console.WriteLine("You entered a String = " + s.ToString());
                    }
                }
            } while (s != null);
            Console.WriteLine("---");
