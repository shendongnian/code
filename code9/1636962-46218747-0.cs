        private void button1_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {             
                richTextBox1.Clear();
                using (StreamReader SR = new StreamReader(OpenFileDialog.FileName))
                {
                    string satir;
                    while ((satir = SR.ReadLine()) != null)
                    {
                        richTextBox1.AppendText(satir + "\n");
                    }
                }
                int sayac = richTextBox1.Lines.Count();
            }   
        }
