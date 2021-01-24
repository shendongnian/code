            foreach (string sFile in Directory.GetFiles(sImportPfad, "*.*", SearchOption.TopDirectoryOnly))
            {
                FileStream iStream;
                try
                {
                    using (iStream = new FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        var sr = new System.IO.StreamReader(iStream, Encoding.UTF8);
                        if (rbCSVfilesMarkieren.Checked)
                        {
                            using (var oStream = new FileStream(sFile + "_new", FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                var sw = new System.IO.StreamWriter(oStream, Encoding.UTF8);
                                int c = 0;
                                while (!sr.EndOfStream)
                                {
                                    String line = sr.ReadLine();
                                    String[] splitLine = line.Trim().Split(txtDivider.Text.Trim().ToCharArray());
                                    if (line.Contains("$$$"))
                                    {
                                        sw.WriteLine(line);
                                        sw.Flush();
                                        continue;
                                    }
                                    String result = Program.myPaletti.Irgendwasneues(splitLine, arrImportFilterObjects);
                                    if (result.Equals("ok"))
                                    {
                                        sw.WriteLine(line + "$$$");
                                        sw.Flush();
                                        anzNeueDatensätze++;
                                    }
                                }
                            }
                        }
                        
                        System.IO.File.Delete(sFile);
                        System.IO.File.Move(sFile + "_new", sFile);
                    }
                }
            }
