    case 1:
        post = new string[2];
        Console.WriteLine("Skriv en titel till ditt inlägg: ");
        post[0] = Console.ReadLine();
        Console.WriteLine("Skriv ett inlägg: ");
        post[1] = Console.ReadLine();
        loggBok.Add(post);
        break;
