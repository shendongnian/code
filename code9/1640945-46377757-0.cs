    string[] strArr1 = string1.Split(' ').ToArray();
    string[] strArr2 = string2.Split(' ').ToArray();
    
    for (int i = 0; i < strArr1.Length; i++)
    {
        if(string.Compare(strArr1[i], strArr2[i]) != 0)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(strArr2[i]);
            Console.ResetColor();
            Console.Write(" ");
        }
        else
        {
            Console.Write(strArr2[i] + " ");
            Console.Write(" ");
        }
    }
