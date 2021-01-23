      dynamic[] result = { "23", "RT", "43", "67", "gf", "43" };
        
                    for(int i=1;i<=result.Count();i++)
                    {
                        var getvalue = result[i];
                        int num;
                        if (int.TryParse(getvalue, out num))
                        {
                            Console.Write(num);
                            Console.ReadLine();
                            // It's a number!
                        }
                    }
