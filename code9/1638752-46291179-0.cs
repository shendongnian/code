    string path1 = "C:\\Support\\Queue.txt";
                if (File.Exists(path1))
                {
                    using (StreamReader sr1 = new StreamReader(path1))
                    {
                        string[] allLine1 = File.ReadAllLines(path1);
                        foreach (var item in allLine1)
                        {
                            comboBox2.Items.Add(item);
                        }
                    }
                }
