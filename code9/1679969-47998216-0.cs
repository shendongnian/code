                            else if (line.Contains("before"))
                            {
                                sw.WriteLine(line.Replace("before", "after"));
                                sw.Write(sr.ReadToEnd());
                                break;
                            }
