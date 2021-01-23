     StringBuilder sb = new StringBuilder();
                using (var sr = new StreamReader("path"))
                {
                    do
                    {
                        var line = sr.ReadLine();
                        sb.Append(line);
                    } while (!sr.EndOfStream);
                }
                textBox1.Text = sb.ToString();
