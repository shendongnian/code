    string a = "This is a long phrase to test the splitting around the middle space";
    string[] parts = a.Split(' ');
    
    int counter = 0;
    string first = "";
    int middle = a.Length / 2;
    while (first.Length < middle)
    {
    	first += parts[counter] + " ";
    	counter++;
    }
    string second = string.Join(" ", parts.Skip(counter));
    Console.WriteLine(first);
    Console.WriteLine(second);
