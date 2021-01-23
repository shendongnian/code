    class Draw
    {
        public Draw(Form form, int x, int y, string kluer, string turnKluer)
        {
            var g = form.CreateGraphics();
            g.Clear();
            Double curX = form.ClientSize.Width * 0.15;
            Double curY = form.ClientSize.Height * 0.2;
            <.... etc ....>
        }
    }
