        private UserControl create_MyControl( string  filenamepath)
        {
            //Create User Control
            UserControl MyControl = new UserControl();
            //Mention the size of control
            MyControl.Size = new Size(100, 100);
            //Create a panel to hold the background image that you wanted in the picture box
            Panel panel1 = new Panel();
            //dock the panel1 to fill the control background
            panel1.Dock = DockStyle.Fill;
            MyControl.Controls.Add(panel1);
            //Create another panel as overlay for panel1
            Panel panel2 = new Panel();
            //dock the panel2 to fill the panel1;
            panel2.Dock = DockStyle.Fill;
            //Add panel2 as child of panel1
            panel1.Controls.Add(panel2);
            //Set panel2 background as transparent 
            panel2.BackColor = Color.Transparent;
            // To replicate the variables that you have!
            Label lblDisplayname = new Label();
            lblDisplayname.Font = new Font("Arial", 24, FontStyle.Regular);
            lblDisplayname.Size = panel2.Size;
            lblDisplayname.TextAlign = ContentAlignment.TopCenter;
            lblDisplayname.Text = "25";
            lblDisplayname.Dock = DockStyle.Fill;
            panel2.Controls.Add(lblDisplayname);
       
            panel1.BackgroundImage = Image.FromFile(filenamepath);
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            //In Panel2 paint event put your code for stuff
            panel2.Paint += (s, e) =>
            {
                var size = TextRenderer.MeasureText("Hello", lblDisplayname.Font);
                var rec = new Rectangle(0, 0, size.Width, size.Width);
               
                var smallFont = new Font(lblDisplayname.Font.Name, lblDisplayname.Font.Size - 1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                format.LineAlignment = StringAlignment.Center;
                using (System.Drawing.Drawing2D.LinearGradientBrush b = new System.Drawing.Drawing2D.LinearGradientBrush(
                    rec,
                    Color.FromArgb(242, 37, 37),
                    Color.FromArgb(178, 30, 30),
                    45F))
                {
                    e.Graphics.FillEllipse(b, rec);
                    e.Graphics.DrawString("Hello", smallFont, Brushes.White, rec, format);
                }
            };
            return MyControl;
        }
