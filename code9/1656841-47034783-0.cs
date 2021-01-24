                Dictionary<decimal, Dictionary<decimal, decimal>> srednicaDict = new Dictionary<decimal, Dictionary<decimal, decimal>>();
                string input = "17.00,60.00,120.00\n" +
                                 "17.00,70.00,120.00\n" +
                                 "17.00,80.00,130.00\n" +
                                 "18.00,80.00,130.00\n" +
                                 "13.00,70.00,135.00";
                StringReader reader = new StringReader(input);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    decimal[] data = line.Split(new char[] { ',' }).Select(x => decimal.Parse(x)).ToArray();
                    Dictionary<decimal, decimal> srednica = null;
                    decimal szerokosc = 0;
                    if (srednicaDict.ContainsKey(data[0]))
                    {
                        srednica = srednicaDict[data[0]];
                        KeyValuePair<decimal, decimal> profil;
                        if (srednica.ContainsKey(data[1]))
                        {
                            szerokosc = srednica[data[1]];
                            if (data[2] == szerokosc)
                            {
                                Console.WriteLine("Data Already in dictionary");
                            }
                            else
                            {
                                srednica.Add(data[1], szerokosc);
                            }
                        }
                        else
                        {
                            srednica.Add(data[1],data[2]);
                        }
                    }
                    else
                    {
                        Dictionary<decimal, decimal> newProfil = new Dictionary<decimal, decimal>();
                        newProfil.Add(data[1], data[2]);
                        srednicaDict.Add(data[0],newProfil);
                    }
                }
 
