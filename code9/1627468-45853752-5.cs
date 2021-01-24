    namespace GradesStr8
    {
        class GradeBook
        {
            public List<float> grades { get; set; }
            private const float passgrade = 70;
    
            public GradeBook()
            {
                grades = new List<float>();
            }
    
            public void AddGrade(float grade)
            {
                grades.Add(grade);
            }
        }
    
        public class program
        {
            public static void Main()
            {
                GradeBook book = new GradeBook();
                book.grades.Add(75);
                book.grades.Add(46);
    
                foreach (float grade in book.grades)
                {
                    Console.WriteLine(grade);
                }
            }
        }
    }
