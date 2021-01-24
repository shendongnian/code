        void pb_MouseEnter( object sender, EventArgs e )
        {
            // sender was my original image. You may need to perform type checks
            PictureBox pb = ((PictureBox)sender);
            // Ignore empty images
            if (pb.Image == null)
                return;
            Form f = new Form();
            f.ControlBox = false;
            f.Enabled = false;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            // Modify to suit your location
            f.Location = new Point( pb.TopLevelControl.Location.X + pb.Location.X - f.Width - 25, MousePosition.Y - f.Height / 2 );
            f.ShowInTaskbar = false;
            f.Size = new System.Drawing.Size( 300, 256 );
            f.StartPosition = FormStartPosition.Manual;
            f.TopMost = true;
            PictureBox pb2 = new PictureBox();
            pb2.Dock = DockStyle.Fill;
            pb2.Image = (Image)pb.Image.Clone();
            pb2.SizeMode = PictureBoxSizeMode.Zoom;
            f.Controls.Add( pb2 );
            pb.Tag = pb2;
            f.Show();
            this.Focus();
        }
        void pb_MouseLeave( object sender, EventArgs e )
        {
            PictureBox pb = ((PictureBox)sender);
            if (pb.Tag != null)
            {
                PictureBox pb2 = (PictureBox)pb.Tag;
                Form f = (Form)pb2.Parent;
                pb2.Dispose();
                f.Dispose();
                pb.Tag = null;
            }
        }
