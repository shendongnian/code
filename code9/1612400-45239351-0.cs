            private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("c:\\temp\\myfile.txt"))
            {
                var txtLines = File.ReadAllLines("c:\\temp\\myfile.txt"); 
                listBox1.Items.AddRange(txtLines);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var sb = new StringBuilder();
            foreach (var i in listBox1.Items)
            {
                sb.AppendLine(i.ToString());
            }
            
            File.WriteAllText("c:\\temp\\myfile.txt", sb.ToString());
        }
