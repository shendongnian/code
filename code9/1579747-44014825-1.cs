      public static List<Question> GetQuestion()
            {
                List<Question> x = new List<Question>();
                using (var db = new Model())
                {
                    x=db.Questions.Include("Course").Include("Answer").ToList();
                }
    
                return x;
            }
