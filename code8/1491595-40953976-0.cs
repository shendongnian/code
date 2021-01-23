        private void FloatingButtons_MouseEnter(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != FormBorderStyle.SizableToolWindow)
            {
                if (this.Tag is Bitmap)
                {
                    Owner.overlay.CreateGraphics().DrawImage(
                        (Bitmap)this.Tag,
                        new Rectangle(
                            Point.Add(this.Location, this.change),
                            this.ClientRectangle.Size),
                        new Rectangle(this.Location, this.ClientRectangle.Size),
                        GraphicsUnit.Pixel
                        );
                }
                this.Hide();
                this.SuspendLayout();
                this.cbBlankDisplay.SuspendLayout();
                this.btnPurgeMessages.SuspendLayout();
                if (this.change.Height == 0)
                {
                    this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                    Rectangle scrPosition = RectangleToScreen(this.ClientRectangle);
                    this.change.Width = (scrPosition.Left - this.Left);
                    this.change.Height = (scrPosition.Top - this.Top);
                }
                this.Left -= this.change.Width;
                this.Top -= this.change.Height;
                this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                this.btnPurgeMessages.ResumeLayout();
                this.cbBlankDisplay.ResumeLayout();
                this.ResumeLayout();
                this.Show();
                if (this.Tag != null && this.Tag is Bitmap)
                {
                    ((Bitmap)this.Tag).Dispose();
                    this.Tag = null;
                    Overlay.performUpdate = true;
                }
            }
        }
