            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                // Create a bitmap the size of my Form
                Bitmap bmp = new Bitmap(this.Bounds.Width, this.Bounds.Height);
                // Copy the form to the newly created Bitmap
                this.DrawToBitmap(bmp, new Rectangle(Point.Empty, this.Bounds.Size));
                // Create a rectangle of the Location and Size of the ClientArea
                Rectangle rect = new Rectangle((Point)this.change, this.ClientRectangle.Size);
                // The Owner Form contains a class that already performs overlays on the screen
                Owner.overlay.CreateGraphics().DrawImage(
                    bmp,
                    new Rectangle(
                        Point.Add(this.Location, this.change),
                        this.ClientRectangle.Size),
                    rect,
                    GraphicsUnit.Pixel
                    );
                // Store the Bitmap in the Tag for Disposal after being used
                this.Tag = bmp;
                // Now I can hide my Form and perform necessary changes
                this.Hide();
                this.SuspendLayout();
                this.cbBlankDisplay.SuspendLayout();
                this.btnPurgeMessages.SuspendLayout();
                this.FormBorderStyle = FormBorderStyle.None;
                this.Left += this.change.Width;
                this.Top += this.change.Height;
                this.btnPurgeMessages.ResumeLayout();
                this.cbBlankDisplay.ResumeLayout();
                this.ResumeLayout();
                this.Show();
            }
