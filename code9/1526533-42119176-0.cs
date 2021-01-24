        private void OnTick(object sender, EventArgs e)
        {
            _graphics.Clear(Color.Aqua);
            _graphics.DrawRectangle(Pens.Black, 10, 10, 10, 10);
            pictureBox1.Image = _bitmap;
        }
