        private void Form1_Load(object sender, EventArgs e)
        {
            Label[] nmr = new Label[10];
            for (int i = 0; i < 10; i++)
            {
                nmr[i] = new Label();
                nmr[i].Text = "label " + i;
                nmr[i].Location = new Point(0, (20 * (i+1)));
                this.Controls.Add(nmr[i]);
            }
        }
