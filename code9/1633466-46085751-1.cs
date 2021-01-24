    //Let's create a gradeTranslator dictionary.
    // As the grades follow the simple divisions along averages divisible by 10,
    // we can just use the first digit of the average to determine the grade.
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool useSampleDate = true;
                Dictionary<string, List<double>> gradeBook = new Dictionary<string, List<double>>();
                Dictionary<int, string> gradeTranslator = new Dictionary<int, string>();
    
                for (int i = 0; i < 6; i++) {
                    gradeTranslator.Add(i, "F");
                }
                gradeTranslator.Add(6, "D");
                gradeTranslator.Add(7, "C");
                gradeTranslator.Add(8, "B");
                gradeTranslator.Add(9, "A");
                gradeTranslator.Add(10, "A");
    
                int TotalStudents, TotalGrades;
    
                // For testing purposes, it is a lot easier to start with some
                // sample data. So, I created a query to see if the user wants 
                // to use sample data or to provide her own input.
                Console.WriteLine("Do you want to input the data (I) or allow me to use sample data (S)?");
                var inputMethod = Console.ReadLine();
    
                if(inputMethod.ToUpper().IndexOf("I") >=0) {
                    useSampleDate = false; 
                }
                // User Sample Data   
                if (useSampleDate) {  // test without using the console input
                    gradeBook.Add("Bob", new List<double>() { 67.8, 26.3, 33.2, 33.1, 67.2 });
                    gradeBook.Add("Dick", new List<double>() { 88.2, 45.2, 100.0, 89.2, 91.5 });
                    gradeBook.Add("Jane", new List<double>() { 99.2, 99.5, 93.9, 98.2, 15.0 });
                    gradeBook.Add("Samantha", new List<double>() { 62, 89.5, 93.9, 98.2, 95.0 });
                    gradeBook.Add("Estefania", new List<double>() { 95.2, 92.5, 92.9, 98.2, 89 });
    
                    TotalStudents = gradeBook.Count();
                    TotalGrades = gradeBook["Bob"].Count();
    
                    TotalStudents = 5;
                
                // user will provide their own data.
                } else { 
    
                    Console.WriteLine("Enter the number of students: ");
                    TotalStudents = Convert.ToInt32(Console.ReadLine());
    
                    Console.WriteLine("Enter the number of exams: ");
                    TotalGrades = Convert.ToInt32(Console.ReadLine());
    
    
    
                    for (int studentId = 0; studentId < TotalStudents; studentId++) {
                        Console.Write("Please enter name of student {0}: ", studentId);
                        var name = Console.ReadLine();
                        gradeBook.Add(name, new List<double>());
                        for (int testId = 0; testId < TotalGrades; testId++) {
                            Console.Write("Please enter exam score {0} for " + 
                            "student {1}: ", testId + 1, name);
                             gradeBook[name].
                             Add(Convert.ToDouble(Console.ReadLine()));
                        }
                    }
                
                }
    
                // Here we will divide the grade by 10 as an integer division to
                // get just the first digit of the average and then translate
                // to a letter grade.
                foreach (var student in gradeBook) {
                    Console.WriteLine("Student " + student.Key + 
                 " scored an average of " + student.Value.Average() + ". " + 
                  student.Key + " will recieve a(n) " + 
                  gradeTranslator[(int)(student.Value.Average() / 10)] + 
                                  " in the class.\n");
                }
    
                Console.Write("\nPress the [ENTER] key to exit.");
                Console.ReadLine();
            }
        }
    }
