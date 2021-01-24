     foreach(var replacement in Replaced.Keys)
         { 
            for (int i = 0; i < arrayofLine.Length;i++ )
                        {
                           
                                if (arrayofLine[i].Contains(replacement))
                                {
                                    countr++;
                                     //if (Frequency.ContainsKey(countr))
                                    //{
                                    //    Frequency[countr] = Frequency[countr] + "|" + replacement;
                                    //}
                                    //else
                                    //{
                                    //    Frequency.Add(countr, replacement);
                                    //}
                                    Frequency.Add(countr, Convert.ToString(replacement));
                                }
                            }
            
                        }
