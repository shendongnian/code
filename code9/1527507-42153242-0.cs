        private void button1_Paint(object sender, PaintEventArgs e)
        {
            var b = sender as Button;
            TextRenderer.DrawText(e.Graphics, b.Text, b.Font, e.ClipRectangle, Color.White, Color.Black);
        }
