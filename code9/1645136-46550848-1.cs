            pictureBox1.Paint += PictureBox1_Paint;
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e) {
            if (setToPaint) {
                if (selectedArtifact == ArtifactType.Line)
                    e.Graphics.DrawLine(Pens.Black, startVal, 100, endVal, 100);
                else if (selectedArtifact == ArtifactType.Rectangle)
                    e.Graphics.DrawRectangle(Pens.Black, startVal, startVal, endVal - startVal, 100);
            }
        }
        private void Draw_Click(object sender, EventArgs e) {
            int.TryParse(txtStart.Text, out startVal);
            int.TryParse(txtEnd.Text, out endVal);
            selectedArtifact = (ArtifactType)shapelist.SelectedItem;
            setToPaint = true;
            pictureBox1.Invalidate();
        }
        private void Clear_Click(object sender, EventArgs e) {
            setToPaint = false;
            pictureBox1.Invalidate();
        }
    }
    enum ArtifactType { None, Line, Rectangle }
