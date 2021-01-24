    public class Grades
    {
        Dictionary<int, char> GradeValues { get; set; }
        public Grades()
        {
            GradeValues.Add(10, 'A');
            GradeValues.Add(9, 'A');
            GradeValues.Add(8, 'B');
            ...
            GradeValues.Add(0, 'F');
        } 
        public char GetGrade(int grade)
        {
            char value = GradeValues[int.Floor(grade/10)];
            if (value == null)
                return 'F';
            return value;
        }
    }
