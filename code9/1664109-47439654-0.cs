      string YourComment = lblComment.text;
        string[] Peaces= a.Split(' ');
        int counter = 0;
        string first = "";
        int Center= a.Length / 2; // Devied it into 2 peaces 
        while (first.Length < Center)
        {
            firstHalf += parts[Peaces] + " ";
            counter++;
        }
        string secondHalf = string.Join(" ", Peaces.Skip(counter)); // Join the string
        string Comment1 = firstHalf ;
        string Comment2 = secondHalf;
