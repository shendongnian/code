    private int SelectCourse(string message)
    {
        int len = _courses.Count;
        int index = -1;
        if (len > 0)
        {
            for (index = 0; index < len; ++index)
            {
                Console.WriteLine($"{index + 1}. {_courses[index].Title}");
            }
            Console.Write(message);
            string selection = Console.ReadLine();
             while (!int.TryParse(selection, out index) || (index < 1 || index > len))
            {
                Console.Write("Please make a valid selection: ");
                selection = Console.ReadLine();
            }
            return --index;
        }
        return --index;
    }
