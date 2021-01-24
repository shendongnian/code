    string s = "Abc.CDE.EFG";
                    string [] n = s.Split('.');
                    n[0] = "ZEF";
                    string p = string.Join(".",n);
                    Console.WriteLine(p);
                }
