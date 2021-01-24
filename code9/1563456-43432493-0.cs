    using (StreamReader reader = new StreamReader("C:\\input"))
                        {
                            using (StreamWriter writer = new StreamWriter("C:\\output"))
                            {
                                while ((line = reader.ReadLine()) != null)
                                {
                                    // if (String.Compare(line, yourName) == 0)
                                    //    continue;
                                    writer.WriteLine(line.Replace(yourName, "");
                                }
                            }
                        }
