    static void DrawField()
    {
        for (column = 0; column < field.GetLength(1); column++)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write((column + 1) + "|");
            Console.ResetColor();
            for (line = 0; line < field.GetLength(0); line++)
            {
                if (field[column, line] == 0)
                {
                    Console.Write("   ");
                }
                else
                {
                    Console.ForegroundColor = p[field[column, line] - 1].color;
                    Console.Write(" " + p[field[column, line] - 1].pawn + " ");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("  ________");
        Console.WriteLine("   1  2  3");
        Console.ResetColor();
    }
