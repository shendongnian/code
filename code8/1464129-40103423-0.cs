    public static void ScrollUpAndDown()
        {
            if (Program.busy != true)
            {
                ConsoleKeyInfo KeyInfo;
                KeyInfo = Console.ReadKey(true);
                switch (KeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        CurrentLine--;
                        indexLog--;
                        if(indexLog >= Program.Log.Count)
                        if(CurrentLine == 5)
                        {
                            ClearText();
                            CurrentLine = Program.intResol_Long - 7;
                        }
                        Console.SetCursorPosition(1, CurrentLine);
                        Program.busy = true;
                        Console.WriteLine(Program.Log[indexLog]);
                        break;
                    case ConsoleKey.DownArrow:
                        CurrentLine++;
                        indexLog++;
                        if (CurrentLine == Program.intResol_Long - 7)
                        {
                            ClearText();
                            CurrentLine = 5;
                        }
                        Console.SetCursorPosition(1, CurrentLine);
                        Program.busy = true;
                        Console.WriteLine(Program.Log[indexLog]);
                        break;
                }
            }
