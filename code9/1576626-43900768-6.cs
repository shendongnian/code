    case 3:
        Console.WriteLine("Skriv in ett ord för att söka bland dina inlägg");
        string keyword = Console.ReadLine();
        foreach (string[] text in loggBok)
        {
            if (text[0].Contains(keyword) || text[1].Contains(keyword))
            {
                Console.Write("\nTitel: " + text[0] + "\n" + text[1]);
            }
        }
        break;
