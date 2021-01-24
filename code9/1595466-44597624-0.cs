    public class QuestionAndAnswers
    {
        public QuestionAndAnswers()
        {
            Answers = new ObservableCollection<Answer>();
        }
        public int Number { get; set; }
        public string Question { get; set; }
        public ObservableCollection<Answer> Answers { get; private set; }
    }
    public class Answer : ICloneable
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public bool IsSelected { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    public class QuestionCollection : List<QuestionAndAnswers>
    {
    }
    public class AnswerCollection : List<Answer>
    {
    }
<!---->
    public partial class QuestionnaireControl : UserControl
    {
        public QuestionnaireControl()
        {
            InitializeComponent();
        }
        public List<QuestionAndAnswers> Questions
        {
            get { return (List<QuestionAndAnswers>) GetValue(QuestionsProperty); }
            set { SetValue(QuestionsProperty, value); }
        }
        public static readonly DependencyProperty QuestionsProperty =
            DependencyProperty.Register("Questions", typeof (List<QuestionAndAnswers>), typeof (QuestionnaireControl),
                new PropertyMetadata(new List<QuestionAndAnswers>(), QuestionsChangedCallback));
        private static void QuestionsChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var q = o as QuestionnaireControl;
            if (q == null)
                return;
            CopyAnswers(q);
        }
        public List<Answer> Answers
        {
            get { return (List<Answer>) GetValue(AnswersProperty); }
            set { SetValue(AnswersProperty, value); }
        }
        public static readonly DependencyProperty AnswersProperty =
                DependencyProperty.Register("Answers", typeof(List<Answer>), typeof(QuestionnaireControl),
                    new PropertyMetadata(new List<Answer>(), AnswersChangedCallback));
        private static void AnswersChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var q = o as QuestionnaireControl;
            if (q == null)
                return;
            CopyAnswers(q);
        }
        private static void CopyAnswers(QuestionnaireControl q)
        {
            if (q.Answers == null || q.Questions == null)
                return;
            foreach (var question in q.Questions)
            {
                // remove old Answers
                question.Answers.Clear();
                // adding new Answers to each question
                foreach (var answer in q.Answers)
                    question.Answers.Add((Answer) answer.Clone());
            }
        }
    }
