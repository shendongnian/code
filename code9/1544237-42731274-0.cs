    foreach (char? c in ThusWord)
    {
       if (c.HasValue)
       {
           Console.Write(c + " ");
       }
       else
       {
           Console.Write("_ ");
       }
    }
