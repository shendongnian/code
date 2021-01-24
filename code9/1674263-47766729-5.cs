            Survey s = 
                new Survey
                {
                    SurveyResults = new SurveyResults
                    {
                        Subject = new Subject
                        {
                            Chapter = new List<Chapter>
                            {
                                {
                                    new Chapter
                                    {
                                        ChapterName = "Chapter 1",
                                        ChapterIterationName = "",
                                        Questions = new List<Question>
                                        {
                                            new Question{ Text="Question 1" },
                                            new Question{ Text="Question 2" }
                                        },
                                        Chapters = new List<Chapter>
                                        {
                                            new Chapter
                                            {
                                                ChapterName = "Chapter 1.1",
                                                ChapterIterationName = "",
                                                Questions = new List<Question>
                                                {
                                                    new Question{ Text="Question 1" },
                                                    new Question{ Text="Question 2" }
                                                }
                                            },
                                            new Chapter
                                            {
                                                ChapterName = "Chapter 1.2",
                                                ChapterIterationName = "",
                                                Questions = new List<Question>
                                                {
                                                    new Question{ Text="Question 1" },
                                                    new Question{ Text="Question 2" }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
            // serialize
            string pathNew = @"G:\Projects\StackOverFlow\WpfApp1\newSurvey.xml";
            FileStream writer = File.Create(pathNew);
            XmlSerializer serializer = new XmlSerializer(typeof(Survey));
            serializer.Serialize(writer, s);
            writer.Close();
            // deserialize
            string path = @"G:\Projects\StackOverFlow\WpfApp1\newSurvey.xml";
            FileStream reader = File.OpenRead(path);
            XmlSerializer ser = new XmlSerializer(typeof(Survey));
            Survey survey = (Survey)ser.Deserialize(reader);
