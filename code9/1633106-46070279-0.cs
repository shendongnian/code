      while ((line = filef.ReadLine()) != null)
                {
                    sb = new StringBuilder();
                    sb.AppendLine(line.Substring(0, line.Length));
                    folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Data\csv\done";
                    using (System.IO.StreamWriter files = new System.IO.StreamWriter(folder + @"\create-user.csv", true))
                    {
                        files.WriteLine(",; " + sb.ToString().Split(';')[1] + ";" + sb.ToString().Split(';')[2] + ";" + sb.ToString().Split(';')[1] + "." + sb.ToString().Split(';')[2] + ";" + GenerateToken(6) + ";" + sb.ToString().Split(';')[3] + ";" + "1" + ";" + "1");
                    }
    
                    folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Data\csv\done";
                    using (System.IO.StreamWriter files = new System.IO.StreamWriter(folder + @"\create-user-archive.csv", true))
                    {
                        files.WriteLine(",; " + sb.ToString().Split(';')[1] + ";" + sb.ToString().Split(';')[2] + ";" + sb.ToString().Split(';')[1] + "." + sb.ToString().Split(';')[2] + ";" + GenerateToken(6) + ";" + sb.ToString().Split(';')[3] + ";" + "1" + ";" + "1");
                    }
                }
                i++;
                sourceFile = System.IO.Path.Combine(@"Data\csv\pending", file);
                filef.Close();
                File.Delete(sourceFile);
