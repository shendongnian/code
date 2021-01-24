        public string MyString = "Hello"
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            var strFont = new Font("Tahoma", 10);
            var strSizeF = g.MeasureString(MyString, strFont);
            var canvas = new Rectangle
            {
                Height = 200,
                Width = 200,
                Location = new Point(10, 10),
            };
            g.DrawRectangle(new Pen(new SolidBrush(Color.Blue)), canvas);
            var nx = (int)(canvas.Width / strSizeF.Width);
            var ny = (int)(canvas.Height / strSizeF.Height);
            var spacingX = (canvas.Width - nx * strSizeF.Width) / (nx-1);
            var spacingY = (canvas.Height - ny * strSizeF.Height) / (ny-1);
            //draw top row and bottom row
            int i;
            for (i = 0; i < nx; i++)
            {
                g.DrawString(
                    MyString,
                    strFont,
                    Brushes.Black,
                    new PointF(canvas.X + i*(strSizeF.Width + spacingX), canvas.Y)
                    );
                g.DrawString(
                    MyString,
                    strFont,
                    Brushes.Black,
                    new PointF(canvas.X + i * (strSizeF.Width + spacingX), canvas.Y + canvas.Height - strSizeF.Height)
                );
            }
            //divide the string into half
            var isLengthOdd = MyString.Length % 2 != 0;
            var substr1 = MyString.Substring(0, MyString.Length / 2 + (isLengthOdd ? 1 : 0));
            var substr2 = MyString.Substring(MyString.Length / 2, MyString.Length - MyString.Length / 2);
            var substr2SizeF = g.MeasureString(substr2, strFont);
            //draw side rows
            for (i = 1; i < ny - 1; i++)
            {
                g.DrawString(
                    substr1,
                    strFont,
                    Brushes.Black,
                    new PointF(canvas.X, canvas.Y + i * (strSizeF.Height + spacingY))
                );
                g.DrawString(
                    substr2,
                    strFont,
                    Brushes.Black,
                    new PointF(canvas.X + canvas.Width - substr2SizeF.Width, canvas.Y + i * (strSizeF.Height + spacingY))
                );
            }
        }
