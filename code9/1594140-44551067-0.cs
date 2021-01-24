    static void Main(string[] args)
    {
        string str = "This is @ my st@ing";
        int numberOfCharacters = 0;
        unsafe
        {
            fixed (char *p = str)
            {
                char *ptr = p;
                while (*ptr != '\0')
                {
                    if (*ptr == '@')
                        numberOfCharacters++;
                    ptr++;
                }
            }
        }
        Console.WriteLine(numberOfCharacters);
    }
