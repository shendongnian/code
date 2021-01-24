    private static string GetName(string question)
    {
        string name = null;
        do
        {
            Console.WriteLine(question);
            try
            {
                name = Console.ReadLine();
            }
            catch (Exception e)
            {
                name = null;
                Console.WriteLine(e.Message);
            }
        } while (string.IsNullOrEmpty(name));
        return name;
    }
