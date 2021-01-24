    namespace GradesStr8 {    
        class GradeBook {
    
    publuc void PrintGrades(List<float> grades)
    {
            float passgrade = 70;
            foreach (float grade in grades) {
            Console.WriteLine(grade);
        }
    }
    
            public void AddGrade(float grade) {    
                grades.Add(grade);    
            }
    
            List<float> grades = new List<float>();    
        }
    }
