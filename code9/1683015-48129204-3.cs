    static void ProgramLoop(string[] args)
    {
        // main loop
        string line;
        while((line = Console.ReadLine()) != String.Empty)
        {
            switch(line)
            {
                case "admin":
                    if (StartSecondInstanceHandler != null)
                    {
                        Console.WriteLine("elevating ...");
                        StartSecondInstanceHandler("/foo:bar /baz:fu");
                        Console.WriteLine("... elevation started");
                    } 
                    else
                    {
                        Console.WriteLine("you are elevated with these arguments: {0}", String.Join(' ',args));
                    }
                break;
                default:
                    Console.WriteLine("you typed '{0}', type 'admin' or leave empty to leave", line);
                break;
            }
        }
    }
