     using (MemoryStream output = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(Server.MapPath("~/CSV/export.csv")))
                {
                   
                   
                    writer.WriteLine(" OVERVIEW");
                    writer.WriteLine("");
                    writer.WriteLine("date : " + DateTimeOffset.Parse(DateTimeOffset.Now.ToString(), CultureInfo.CurrentCulture).ToString("yyyy-MM-dd"));
                  
                    writer.WriteLine("Name");
                    writer.WriteLine("Property");
                   
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("Name,Property");
                    foreach (var item in List)
                    {
                        writer.WriteLine(string.Format("{0},{1}",
                                                   item.Name,
                                                   item.Property
                                                  
                                                   ));
                    }
                    writer.Flush();
                    output.Position = 0;
                    // var document=Server.MapPath("~/Content/ExportedFiles/Exported_Users.csv");
                }
            }
