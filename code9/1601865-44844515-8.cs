      // Circle:
      double centerx = 1;
      double centery = 1;
      double r = 1.5;
      // Rectangle:
      double left = -1;
      double top = 1;
      double width = 6;
      double height = 2;
      // Point to test:
      double x = 2.5;
      double y = 2.0;
      string rectTest = IsWithinRectangle(x, y, left, top, width, height) 
        ? "within rect" 
        : "outside rect";
      string circleTest = IsWithinCircle(x, y, centerx, centery, r) 
        ? "within circle" 
        : "outside circle";
      Console.Write(string.Join(" & ", circleTest, rectTest));
