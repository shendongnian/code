    foreach (var name in names.ToList())
                {
                   
                    if (regex.IsMatch(name.InnerText))
                    {
                        name.Remove();
                        work.Save();
                    
                    }
                }
