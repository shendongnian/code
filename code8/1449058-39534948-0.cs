    if(cki.Key == ConsoleKey.Backspace && name.Length >= 0)
    {
        if (name.Length == 0)
        {
            name.Remove(0, 0);
        }
        else
        {
            name.Remove(name.Length - 1, 1);
        }
         temp--;
        Console.Write(" ");   
    }
