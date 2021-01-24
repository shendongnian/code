    class GradeBook
    {
        private readonly List<float> _grades;
        private const float PASSGRADE = 70;
        public GradeBook()
        {
            _grades = new List<float>();
        }
        
        public void AddGrade(float grade)
        {
            _grades.Add(grade);
        }
        //Your new function
        public float Sum()
        {
            float sum = 0;
            foreach (float grade in _grades)
            {
                sum += grade;
            }
            return sum;
        }
    }
