    switch (dot)
            {
                case 1:
                    Console.SetCursorPosition(0, Console.CursorTop-1);
                     var str = ".";
                    var padded = str.PadRight(2);
                    Console.WriteLine(str);
                    dot++;
                    Thread.Sleep(500);
                    break;
                case 2:
                    Console.SetCursorPosition(0, Console.CursorTop -1);
                    Console.WriteLine("..");
                    dot++;
                    Thread.Sleep(500);
                    break;
                case 3:
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine("...");
                    dot = 1;
                    Thread.Sleep(500);
                    break;
            }
