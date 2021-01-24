    var lines =File.ReadAllLines(@"C:\Users\person\Desktop\C#\New Text Document.txt");
                foreach (var line in lines)
                {
                    var col = line.Split(',');
                    textBox1.Text = col[0]; 
                       textBox2.Text = col[1];
                    textBox3.Text = col[2];
                    textBox4.Text = col[3]; 
                } 
