    string[] fileContents = File.ReadAllLines("joci.txt");
    Student[] students = new Student[fileContents.Length / 2];
    for (int i = 0, j = 0; i < fileContents.Length; i += 2, j++)
    {
        string name = fileContents[i];
        int av = 0;
        if ( int.TryParse( fileContents[i + 1], out av ) {
            students[j] = new Student { name = name, average = av };
            Console.WriteLine(students[j].name + " - " + students[j].avarage);
        }
    }
    Console.ReadKey();
