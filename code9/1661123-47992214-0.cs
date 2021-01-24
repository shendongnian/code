                    {
                        StreamWriter sw = null;
                        using (var stream = File.Open(mgrFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
                        {
                            using (sw = new StreamWriter(stream))
                            {
                                sw.Write("ak@test.com");
                            }
                        }
                    }
                    else
                    {
                        mgrMail = File.ReadAllText(mgrFile);
                    }
