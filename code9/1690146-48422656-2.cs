    StringBuilder sb = new StringBuilder();
    foreach (string item in ReadLines) {
        if (item == "Start Details") {
            DetailsFound = true;
        }
        else if (item == "End Details") {
            break;
        }
        else if (DetailsFound) {
            Console.WriteLine("Details - " + item);
            sb.AppendLine(item);
            // VARIABLE / STRING REQUIRED HERE
        }
    }
    string output = sb.ToString();
