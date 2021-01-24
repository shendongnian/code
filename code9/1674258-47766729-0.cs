        public class Chapter
        {
            public string ChapterName { get; set; }
            public string ChapterIterationName { get; set; }
            public List<Chapter> Chapters { get; set; }
            public List<Question> Questions { get; set; }
        }
        public class Questions
        {
            public List<Question> Question { get; set; }
        }
        public class Question
        {
            public string Text { get; set; }
        }
        public class Survey
        {
            public SurveyResults SurveyResults { get; set; }
        }
        public class SurveyResults
        {
            public Subject Subject { get; set; }
        }
        public class Subject
        {
            public List<Chapter> Chapter { get; set; }
        }
