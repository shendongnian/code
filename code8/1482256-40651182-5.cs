    using (SqlCommand command = dbConnection.connection.CreateCommand())
                {
                    command.CommandText = "SELECT Quiz.name, QuizCategory.quizId, QuizCategory.categoryId, Category.name AS catName, Question.[description], Answer.[description] FROM Quiz JOIN QuizCategory ON QuizCategory.quizId = Quiz.id JOIN Category ON Category.id = QuizCategory.categoryId JOIN Question ON Question.categoryId = Category.id JOIN Answer ON Answer.questionId = Question.id WHERE Quiz.id = @id";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if(quiz==null)
                        {
                            quiz = new Quiz();
                            quiz.name = reader.GetString(reader.GetOrdinal("name"));
                            quiz.id = reader.GetInt32(reader.GetOrdinal("quizId"));
                        }
                        if(question!=null)
                        {
                            //You'll need to get the question ID or just use the description here instead for comparison
                            if(question.id!=reader.GetInt32(reader.GetOrdinal("questionId"))
                            {
                                category.question.Add(question);
                                question = new Question();
                                question.description = reader.GetString(reader.GetOrdinal("description"));
                            }
                        }
                        else
                        {
                            question = new Question();
                            question.description = reader.GetString(reader.GetOrdinal("description"));
                        }                        
                        
                        if(category!=null)
                        {
                            if(category.id!=reader.GetInt32(reader.GetOrdinal("categoryId"))
                            {
                                quiz.categories.Add(category);
                                category = new Category();
                                category.id = reader.GetInt32(reader.GetOrdinal("categoryId"));
                                category.name = reader.GetString(reader.GetOrdinal("catName"));
                            }
                        }
                        else
                        {
                            category = new Category();
                            category.id = reader.GetInt32(reader.GetOrdinal("categoryId"));
                            category.name = reader.GetString(reader.GetOrdinal("catName"));
                        }
                        answer = new Answer();
                        answer.description = reader.GetString(reader.GetOrdinal("description"));
                        question.Answers.Add(answer);
    
                    }
                }
                if(question!=null)
                {
                    category.question.Add(question);
                }
                if(category!=null)
                {
                    quiz.categories.Add(category);
                }
