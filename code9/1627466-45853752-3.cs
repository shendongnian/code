    namespace GradesStr8 {    
        class GradeBook {
    
            List<float> grades = new List<float>();
            float passgrade = 70;    
    publuc void PrintGrades()
    {
            
            foreach (float grade in grades) {
            Console.WriteLine(grade);
        }
    }
    
            public void AddGrade(float grade) {    
                grades.Add(grade);    
            }
        }
    }
