    int choice;
    do {
        PrintMenu ();
        choice = Int32.Parse (Console.ReadLine ());
        ProcessChoice(choice, MBR);
    } //...
