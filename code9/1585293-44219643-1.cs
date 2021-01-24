    class StudentApp
    {
        public double PromoteScore(List<Student> list)
        {
            double promotion = 0;
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
            return promotion;
        }
    }
