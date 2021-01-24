    Dictionary<string, List<int>> examGrades = new Dictionary<int, List<int>>();
    for(int i = 0; i < 10; i++)
    {
        Console.Write("Student's name: ");
        string name = Console.ReadLine();
        Console.Write("Student's mark (type 0 at the end): ");
        List<int> marks = new List<int>();
        int mark = 0;
        do
        {
            int mark = Convert.ToInt32(Console.ReadLine());
            marks.Add(mark);
            if(mark == 0)
                break;
        } while(true);
        examGrades.Add(name, marks);
    }
