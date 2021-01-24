        point a = new point();
        a.TouchGround = 1;
        // Next lines, create a shallow copy of a and put into b.
        point b = (point)a.Clone();
        b.TouchGround = 20;
        Console.WriteLine(a.TouchGround);
        Console.WriteLine(b.TouchGround);
        Console.ReadLine();
