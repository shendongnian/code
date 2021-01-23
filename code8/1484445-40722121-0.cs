    using System;
    using GradeBookNameSpace.GradeBook;
    public class GradeBookTest
    {
        public static void Main(string[] args)
        {
        GradeBook myGradeBook = new GradeBook();
        Console.WriteLine("Initial course name is: '{0}'\n", myGradeBook.CourseName);
        Console.WriteLine("Please enter course name:");
        myGradeBook.CourseName = Console.ReadLine();
        Console.WriteLine();
        myGradeBook.DisplayMessage();
        }
    }
