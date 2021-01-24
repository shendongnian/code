    List<string> list = new List<string>();
    foreach (string item in ReadLines) {
        if (item == "Start Details") {
            DetailsFound = true;
        }
        if (item == "End Details") {
            break;
        }
        if (DetailsFound) {
            Console.WriteLine("Details - " + item);
            list.Add(item);
            // VARIABLE / STRING REQUIRED HERE
        }
    }
    // list holds all lines
