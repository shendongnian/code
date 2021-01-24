    using static System.Console;
    switch (g)
    {
        // check that g is a Triangle and deconstruct it into local variables
        case Triangle(int Width, int Height, int Base):
            WriteLine($"{Width} {Height} {Base}");
            break;
        // same for Rectangle
        case Rectangle(int Width, int Height):
            WriteLine($"{Width} {Height}");
            break;
        // same for Square
        case Square(int Width):
            WriteLine($"{Width}");
            break;
        // no luck
        default:
            WriteLine("<other>");
            break;
    }
