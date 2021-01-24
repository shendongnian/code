    static void KeyRead()
    {
        do
        {
            int i = (int)Console.ReadKey().KeyChar;
            if (i == 49)
            {
                Console.Out.Write("Key 1 pressed");
            }
        } while (true);
    }
