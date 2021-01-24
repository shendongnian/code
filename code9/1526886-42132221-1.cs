        // Add this lines to InitializeComponent() in yourform.Designer.cs
        this.label1.TextChanged += new System.EventHandler(this.label_TextChanged);
        this.label2.TextChanged += new System.EventHandler(this.label_TextChanged);
        // this is label1 and label2 TextCahanged Event
        private void label_TextChanged(object sender, EventArgs e)
        {
            SetMultiColorText(string.Format("{0} = {1}", label1.Text, label2.Text),label3);
        }
    // this method set multi color image text for label(paramter lb)
        public void SetMultiColorText(string Text, Label lb)
        {
            lb.Text = "";
            // PictureBox needs an image to draw on
            lb.Image = new Bitmap(lb.Width, lb.Height);
            using (Graphics g = Graphics.FromImage(lb.Image))
            {
                
                
                SolidBrush brush = new SolidBrush(Form.DefaultBackColor);
                g.FillRectangle(brush, 0, 0,
                    lb.Image.Width, lb.Image.Height);
                
                string[] chunks = Text.Split('=');
                brush = new SolidBrush(Color.Black);
                // you can get this colors from label1 and label2 colors... or from db.. or an other where you want
                SolidBrush[] brushes = new SolidBrush[] { 
            new SolidBrush(Color.Black),
            new SolidBrush(Color.Red) };
                float x = 0;
                for (int i = 0; i < chunks.Length; i++)
                {
                    // draw text in whatever color
                    g.DrawString(chunks[i], lb.Font, brushes[i], x, 0);
                    // measure text and advance x
                    x += (g.MeasureString(chunks[i], lb.Font)).Width;
                    // draw the comma back in, in black
                    if (i < (chunks.Length - 1))
                    {
                        g.DrawString("=", lb.Font, brush, x, 0);
                        x += (g.MeasureString(",", lb.Font)).Width;
                    }
                }
            }
        }
