    int x = Cursor.Position.X;
    int y = Cursor.Position.Y;
    int size = 10; // Arbitrary size
    System.Drawing.Graphics graphics = CreateGraphics();
    System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(x - (size / 2), y - (size / 2), size, size);
    graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
