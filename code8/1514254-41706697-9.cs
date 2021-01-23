    var db = new DBContext() // => this is your database context
    var result = (from s in db.Surveys
                 select new SurveyDTO(){
                   survey = s,
                   categories = (from c in db.Categories
                                where c.SurveyID = s.ID
                                select new CategoriesDTO(){
                                   category = c,
                                   questions = (from q in db.Questions
                                               where q.CategoryID = c.ID
                                               select new QuestionsDTO(){
                                                   question = q,
                                                   answers = (from a in db.Answers
                                                             where a.QuestionID = q.ID
                                                             select a).ToList()
                                                }).ToList() // close the questions
                                }).ToList() // close the categories
                }).ToList();// close the surveys
    return result;
