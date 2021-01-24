    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace DelegateDemo_2 {
        class Program {
            delegate bool IsTeenAge(Student stud);
            static void Main(string[] args) {
                // reference: http://www.tutorialsteacher.com/linq/linq-lambda-expression
                IsTeenAge isteenage = new IsTeenAge(CheckAge);
                Student stud1 = new Student() { Age = 17 };
                Console.WriteLine(isteenage(stud1));
                Console.ReadKey();
            }
            static bool CheckAge(Student s) {
                return s.Age > 12 && s.Age < 18;
            }
        }
    }
