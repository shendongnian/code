    using(StringReader reader=new StringReader(richTextBox1.Text))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        // Checking if the line contains things other than letters
                        line = new String(line.Where(x => Char.IsDigit(x)).ToArray()); //here, we remove all non-digits from the line variable
                        Regex rx = new Regex("^[730-9]{9}$");
                        if (rx.IsMatch(line))
                        {
                            richTextBox2.Text+=line;
                        }
                    }
                } while (line != null);
            }}
