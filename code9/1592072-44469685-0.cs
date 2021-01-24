        Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();
        List<string> students = new List<string>();
        //adding Elements to list
        students.Add("Raees Ul Islam");
        students.Add("Ubaid Ur Rehman");
        //adding item to dictionary
        dictionary.Add(1, students);
        //Retriveing Data from Dictionary..
        Console.WriteLine(((List<string>)dictionary[1])[0]);
        Console.WriteLine("---------------");
        //An Other Way to go through All Elements
        List<string> studentsRetrived = dictionary[1];
        foreach (var item in studentsRetrived)
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();
