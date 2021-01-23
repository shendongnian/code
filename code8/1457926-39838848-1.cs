    string datetime = DateTime.Now.ToString("hh:mm tt");
    // False
    Console.WriteLine(datetime == "2:06 PM");
            // False
            Console.WriteLine(datetime == "2:06 P.M.");
            // False
            Console.WriteLine(datetime == "2:06");
            // False
            Console.WriteLine(datetime == "02:06 P.M.");
            // True
            Console.WriteLine(datetime == "02:06 PM");
