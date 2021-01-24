       this.BeginInvoke(new Action(() => {
            using (Image prev = pictureBox1.Image) {
                pictureBox1.Image = bmp;
            }
        }));
