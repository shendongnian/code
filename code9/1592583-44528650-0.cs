                Logs.Flush();
                using (FileStream Steam = File.Open(txt, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader Reader = new StreamReader(Steam))
                    {
                        while (!Reader.EndOfStream)
                        {
                            textBox1.Text = Reader.ReadToEnd();
                            break;
                        }
                    }
                }
