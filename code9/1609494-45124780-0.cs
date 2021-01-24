    List<string> uniqueNames = new List<string>();           
                  foreach(DataGridViewRow r in view.Rows)
                  {
                      FileStream file;
                    
                      if (!uniqueNames.Contains(r.Cells["FileName"].Value.ToString()))
                      {
                          file = File.OpenWrite("yourPath\\" + r.Cells["FileName"].Value.ToString());
                        byte[] array = Encoding.UTF8.GetBytes(r.Cells["Data"].Value.ToString());
                         
                          file.Write(array, 0,array.Length);
                          file.Close();
                          uniqueNames.Add(r.Cells["FileName"].Value.ToString());
                      }
    
                  }
