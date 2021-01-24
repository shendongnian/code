    private static void Main()
    {
        var studentOne = new Student { Name = "Bob" };
        var studentTwo = Student.CreateFrom(studentOne);
        Console.WriteLine(studentOne);
        Console.WriteLine(studentTwo);
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
