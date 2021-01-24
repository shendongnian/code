        public class Program
        {
            private int total;  // sum of grades
            private int gradeCounter; //number of grades entered
            private int aCount; // Count of A grades
            private int bCount; // Count of B grades
            private int cCount; // Count of C grades
            private int dCount; // Count of D grades
            private int fCount; // Count of F grades
            private string v;
            private static int counter = 0;
    
    
            public string CourseName { get; set; }
    
            public Program(string name)
            {
                CourseName = name;
            }
    
            public void DisplayMessage()
            {
                Console.WriteLine("Welcome to the grade book for \n{0}!\n",
                    CourseName);
            }
    
            public void InputGrade()
            {
                int grade;
                string input;
    
                Console.WriteLine("{0}\n{1}",
                    "Enter the integer grades in the range 0-100",
                    "Type <Ctrl> z and press Enter to terminate input:");
                counter++;
                System.Console.Write("score " + counter + ":");
                input =  Console.ReadLine(); //read user input
    
                while (input != null)
                {
                    grade = Convert.ToInt32(input); //read grade off user input
                    total += grade;// add grade to total
                    gradeCounter++; //  increment number of grades
    
                    IncrementLetterGradeCounter(grade);
                    counter++;
                    System.Console.Write("score " + counter + ":");
                    input = Console.ReadLine();
                }
            }
            private void IncrementLetterGradeCounter(int grade)
            {
                switch (grade / 10)
                {
                    case 9: //grade was in the 90s
                    case 10:
                        ++aCount;
                        break;
                    case 8:
                        ++bCount;
                        break;
                    case7:
                        ++cCount;
                    case6:
                        ++dCount;
                        break;
                    default:
                        ++fCount;
                        break;
    
                }
            }
            public void DisplayGradeReport()
            {
                Console.WriteLine("\nGrade Report");
    
                if (gradeCounter != 0)
                {
                    double average = (double)total / gradeCounter;
    
                    Console.WriteLine("Total of the {0} grades entered is {1}",
                        gradeCounter, total);
                    Console.WriteLine("class average is {0:F}", average);
                    Console.WriteLine("{0}A: {1}\nB: {2}\nC: {3}\nD: {4}\nF: {5} ",
                        "Number of students who received each grade: \n",
                       aCount,
                       bCount,
                       cCount,
                       dCount,
                       fCount);
                }
                else
                    Console.WriteLine("No grades were entered");
            }
            static void Main(string[] args)
            {
                Program mygradebook = new Program(
                    "CS101 introduction to C3 programming");
                mygradebook.DisplayMessage();
                mygradebook.InputGrade();
                mygradebook.DisplayGradeReport();
                Console.ReadKey();
            }
        }
