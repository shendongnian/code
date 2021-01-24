    foreach (string file in Directory.GetFiles(parent_path))
            {
                extension = Path.GetExtension(file);
                if (extension.ToUpper().Equals(sfileType.ToUpper()))
                {
                    TimeSpan fileAge = DateTime.Now - File.GetLastWriteTime(file);
                    if (fileAge.Days > int.Parse(ConfigurationManager.AppSettings["numberOfDays"]))
                    {
                        count++;
                    }
                }
            }
