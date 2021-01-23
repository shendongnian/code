    string[] fileContents = File.ReadAllLines("joci.txt");
    Student[] students = new Student[fileContents.Length / 2];
    for (int i = 0; i < fileContents.Length; i += 2)
    {
        string name = fileContents[i];
        int av = 0;
        if ( int.TryParse( fileContents[i + 1], out av ) {
            students[i] = new Student { name = name, average = av };
            Console.WriteLine(students[i].name + " - " + students[i].avarage);
        }
    }
    Console.ReadKey();
