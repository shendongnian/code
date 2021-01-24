    public static void dragRectangle(int x, int y, int width, int height) {
      Console.ForegroundColor = ConsoleColor.Yellow;
      //set top corners
      string curCorner = "╔";
      Console.SetCursorPosition(x, y);
      Console.WriteLine(curCorner);
      curCorner = "╗"; ;
      Console.SetCursorPosition(x + width + 1, y);
      Console.WriteLine(curCorner);
      //set bottom corners
      curCorner = "╚";
      Console.SetCursorPosition(x, y + height);
      Console.WriteLine(curCorner);
      curCorner = "╝";
      Console.SetCursorPosition(x + width + 1, y + height);
      Console.WriteLine(curCorner);
      // set top/bottom horizontal bar
      string horizontalBar = new string('═', width);
      Console.SetCursorPosition(x + 1, y);
      Console.WriteLine(horizontalBar);
      Console.SetCursorPosition(x + 1, y + height);
      Console.WriteLine(horizontalBar);
      // set left/right vertical bar
      string vertBar = "║";
      for (int i = 1; i < height; i++) {
        Console.SetCursorPosition(x, y + i);
        Console.WriteLine(vertBar);
        Console.SetCursorPosition(x + width + 1, y + i);
        Console.WriteLine(vertBar);
      }
      Console.ResetColor();
    }
