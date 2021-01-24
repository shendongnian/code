    StringBuilder sb = new StringBuilder();
    foreach (string item in ReadLines) {
        if (item == "Start Details") {
            DetailsFound = true;
        }
        if (item == "End Details") {
            break;
        }
        if (DetailsFound) {
            Console.WriteLine("Details - " + item);
            sb.AppendLine(item);
            // VARIABLE / STRING REQUIRED HERE
        }
    }
    string output = sb.ToString();
