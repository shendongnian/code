    public enum TestType
    {
        Quiz,
        Exam,
        Exercise,
    }
    public class TestScore
    {
        public TestType Type { get; set; }
        public DateTime Date { get; set; }
        public int      Score { get; set; }
        public int      SubjectId { get; set; }
        // Constructors - make a TestScore object
        public TestScore(QuizModel q)
        {
            Type      = TestType.Quiz;
            Date      = q.quizDate;
            Score     = q.quizScore;
            SubjectId = q.SubjectId;            
        }
        public TestScore(ExamModel e)
        {
            Type      = TestType.Exam;
            Date      = e.examDate;
            Score     = e.examScore;
            SubjectId = e.SubjectId;            
        }
        public TestScore(ExerciseModel e)
        {
            Type      = TestType.Exercise;
            Date      = e.exerciseDate;
            Score     = e.exerciseScore;
            SubjectId = e.SubjectId;            
        }
    }
