    string inputString = String.Empty;
    do {
             keyInfo = Console.ReadKey(true);
    // Handle backspace.
             if (keyInfo.Key == ConsoleKey.Backspace) {
                // Are there any characters to erase?
                if (inputString.Length >= 1) { 
                   // Determine where we are in the console buffer.
                   int cursorCol = Console.CursorLeft - 1;
                   int oldLength = inputString.Length;
                   int extraRows = oldLength / 80;
    
                   inputString = inputString.Substring(0, oldLength - 1);
                   Console.CursorLeft = 0;
                   Console.CursorTop = Console.CursorTop - extraRows;
                   Console.Write(inputString + new String(' ', oldLength - inputString.Length));
                   Console.CursorLeft = cursorCol;
                }
                continue;
             }
             // Handle Escape key.
             if (keyInfo.Key == ConsoleKey.Escape) break;
     Console.Write(keyInfo.KeyChar);
     inputString += keyInfo.KeyChar;
     } while (keyInfo.Key != ConsoleKey.Enter);
