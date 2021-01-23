    var db = new DBContext() // => this is your database context
    var result = from s in db.Surveys
                 select new {
                   survey = s,
                   categories = from c in db.Categories
                                where c.SurveyID = s.ID
                                select new {
                                   category = c,
                                   questions = from q in db.Questions
                                               where q.CategoryID = c.ID
                                               select new {
                                                   question = q,
                                                   answers = from a in db.Answers
                                                             where a.QuestionID = q.ID
                                                             select a
                                                } // close the questions
                                } // close the categories
                };// close the surveys
    return result;
