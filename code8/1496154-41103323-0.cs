    Console.Write("\tWhich log number do you want to change? : ");
    string change = "Log number: " + Console.ReadLine();
    foreach (string[] item in logBook)  // För varje element(item) i Listan(logBook) dvs (arr[i])
    {
        if (item[0].Contains(change))  // Om arr[0], arr[1] eller arr[2] innhåller sökord....,
        {
            string timeDate2 = time.ToLongDateString();  // Ger oss ett datum för inlägget.
            Console.Write("\tWrite a title to your post: ");
            string title2 = "Title: " + Console.ReadLine();  // Ger oss en titel för inlägget.
            Console.Write("\n\tPost is created " + timeDate2 + "\n\n\tWrite your post: ");
            string post2 = Console.ReadLine();
            item[1] = timeDate2;
            item[2] = title2;
            item[3] = post2;
        }
    }
