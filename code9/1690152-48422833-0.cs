    string WriteDataHere = String.Empty; // <- 
    bool DetailsFound = false;
    string[] ReadLines = File.ReadAllLines(path);
    foreach (string item in ReadLines) {
        if (item == "Start Details") {
        DetailsFound = true;
    }
    if (DetailsFound) {
        Console.WriteLine("Details - " + item);
        // VARIABLE / STRING REQUIRED HERE
        WriteDataHere += item; // <--
        }
        if (item == "End Details") {
            break;
        }
    }
