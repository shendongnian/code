    var detailsFound = false;
    var readLines = File.ReadAllLines(path);
    var stringB = new StringBuilder();
    foreach (string item in ReadLines) {
        if (item == "Start Details") {
            DetailsFound = true;
        }
        else if (item == "End Details") {
            break;
        }
        else if (DetailsFound) {
            Console.WriteLine("Details - " + item);
            stringB.AppendLine(item);
        }
    }
