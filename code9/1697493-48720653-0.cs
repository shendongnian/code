     private void Form1_Load(object sender, EventArgs e)
            {
                if(glassButton1.Text.Length>5)
                {
                    int sum = glassButton1.Text.Length - 5;
                    string line1 = glassButton1.Text.Substring(0, 5);
                    string line2 = glassButton1.Text.Substring(glassButton1.Text.Length - sum);
                    glassButton1.Text = line1 + Environment.NewLine + line2;
                }
            }
    
            private void glassButton1_Click(object sender, EventArgs e)
            {
                string[] lines = glassButton1.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string address = lines[0];
                string address2 = lines[1];
                MessageBox.Show(address+address2);
            }
