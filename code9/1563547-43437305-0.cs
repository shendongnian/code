            var lines = File.ReadAllLines("C:\\My File2.txt");
            int i;
            for (i = 0; i<lines.Length;i++)
            {
                var line1 = lines[i];
                if (line1 == "!" || line1 == " ") continue;
                if (line1.StartsWith("access-list")) && (!line1.Contains("remark ")))
                {
                    TextBox1.Text = TextBox1.Text + "\r\n" + line1;
                }
                else if (line1.StartsWith("nat"))
                {
                     TextBox2.Text = TextBox2.Text + "\r\n" + line1;
                }
                if (line1.StartsWith("interface"))
                {
                    var str = line1;
                    while (!Equals(lines[i + 1], "!"))
                    {
                        str += lines[i + 1];
                        i++;
                    }
                    TextBox3.Text = TextBox3.Text + "\r\n" + str;
                }
            }
