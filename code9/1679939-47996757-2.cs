    public static void WriteLine(String str, Boolean line = true)
    {
        lock (m_Lock)
        {
            if (line)
            {
                Console.WriteLine(str);
                OutputSingleton.SW.WriteLine(str);
            }
            else
            {
                Console.Write(str);
                OutputSingleton.SW.Write(str);
            }
        }
    }
