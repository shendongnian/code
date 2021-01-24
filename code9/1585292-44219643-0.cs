    class StudentApp
    {
        public double Promotion { get; private set; }
        public void PromoteScore(List<Student> list)
        {
            foreach (Student s in Students)
            {
                if (s.Score + 10 > 100)
                {
                    Promotion = 100;
                }
                else
                {
                    Promotion = s.Score + 10;
                }
            }
        }
    }
