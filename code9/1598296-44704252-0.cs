        private void button1_Click(object sender, EventArgs e)
        {
            string HorseFile = @"C:\Users\mikes\Documents\SomeFile.txt";
            int count = 0;
            foreach(string HorseName in File.ReadLines(HorseFile))
            {
                LinkLabel HorseLabel = new LinkLabel();
                HorseLabel.Left = 35;
                HorseLabel.Top = (count + 4) * 21;
                HorseLabel.Text = HorseName;
                HorseLabel.LinkClicked += HorseLabel_LinkClicked; // wire up the event
                this.Controls.Add(HorseLabel);
                count++;
            }
        }
        private void HorseLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel Horse = (LinkLabel)sender;
            MessageBox.Show(Horse.Text);
        }
