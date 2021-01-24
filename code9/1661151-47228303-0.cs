    public byte[] WriteItem<T>(List<T> collection) where T : class
            {
                
    
                Type t = typeof(T);
                string newLine = Environment.NewLine;
    
                object obj = Activator.CreateInstance(t);
                PropertyInfo[] props = obj.GetType().GetProperties();
                byte[] carriageReturnBytes = System.Text.Encoding.UTF8.GetBytes("\r");
    
                string text;
                using (MemoryStream ms = new MemoryStream())
                using (StreamReader sr = new StreamReader(ms))
                {
                    foreach (PropertyInfo pi in props)
                    {
                        byte[] data = System.Text.Encoding.UTF8.GetBytes(pi.Name.ToString() + ",");
                        ms.Write(data, 0, data.Length);
                    }
    
                    ms.Write(carriageReturnBytes, 0, carriageReturnBytes.Length);
    
                    foreach (T item in collection)
                    {
                        foreach (PropertyInfo pi in props)
                        {
                            string write =
                               Convert.ToString(item.GetType().GetProperty(pi.Name).GetValue(item, null)).Replace(",", " ") + ',';
    
                            byte[] data = System.Text.Encoding.UTF8.GetBytes(write);
                            ms.Write(data, 0, data.Length);
                        }
    
                        byte[] writeNewLine = System.Text.Encoding.UTF8.GetBytes(Environment.NewLine);
                        ms.Write(writeNewLine, 0, writeNewLine.Length);
                    }
    
                    ms.Position = 0;
                    text = sr.ReadToEnd();
                    return ms.ToArray();
                }
            }
