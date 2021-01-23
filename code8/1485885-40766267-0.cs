    class Etape : Panel
        {
            public Etape()
            {
                MouseDown += Etape_MouseDown;
                MouseMove += Etape_MouseMove;
            }
    
            private Point MouseDownLocation;
    
            private void Etape_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    MouseDownLocation = e.Location;
                    this.BackColor = CouleurSelect;
                    MessageBox.Show("Bonjour");
                }
            }
    
            private void Etape_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.Left = e.X + this.Left - MouseDownLocation.X;
                    this.Top = e.Y + this.Top - MouseDownLocation.Y;
                }
            }
        }
