    // DESCRIPTION
                {
                    BinaryReader br7 = new BinaryReader(File.OpenRead(OpenFileDialog1.FileName));
                    br7.BaseStream.Position = 0x1c8;
                    Char[] charArray = br7.ReadChars(40);
                    string Desc = new string(charArray);
                    textBox11.Text = Desc;
                    if (textBox11.Text.All(c => char.IsWhiteSpace(c)))
                    {
                        textBox11.ForeColor = Color.Orange;
                        textBox11.Text = "No Value!";
                    }
                    else textBox11.ForeColor = Color.Black;
                    br7.Close();
