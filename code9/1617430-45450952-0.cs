     using System.IO;
     public void WriteToFile(string newData, string _txtfile)
        {
            List<string> ListToWrite = new List<string>();
            /// Reads every line from the file
            try
            {
                using (StreamReader rd = new StreamReader(_txtfile, true))
                {
                    while (true)
                    {
                        ListToWrite.Add(rd.ReadLine().Trim());
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                /// Check if the string that you want to insert is already on the file
                var x = ListToWrite.Single(a => a.Contains(newData));
                /// If there's no exception, means that it found your string in the file, so lets delete it.
                ListToWrite.Remove(x);
            }
            catch (Exception)
            {
                /// If a exception is thrown, it did not find your string so add it.
                ListToWrite.add(newData);
            }
            
            /// Now is time to write the NEW file.
            if (ListToWrite.Count > 0)
              {
                  using (StreamWriter tw = new StreamWriter(_txtfile, true))
                  {
                      try
                      {
                          foreach (string s in l)
                          {
                              tw.WriteLine(s);
                          }
                      }
                      catch (Exception)
                      {
                          break;
                      }
                  }
              }
        }
