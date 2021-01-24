    public partial class QuestionnaireControl : UserControl
    {
        public QuestionnaireControl()
        {
            InitializeComponent();
            Questions = new List<QuestionAndAnswers>();
            Answers = new ObservableCollection<Answer>();
            Answers.CollectionChanged += Answers_CollectionChanged;
        }
        private void Answers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var question in Questions)
            {
                question.Answers = new List<Answer>();
                foreach (var answer in Answers)
                {
                    question.Answers.Add(new Answer() { Text = answer.Text, Value = answer.Value, IsSelected = answer.IsSelected });
                }
            }
        }
        public List<QuestionAndAnswers> Questions
        {
            get { return (List<QuestionAndAnswers>)GetValue(QuestionsProperty); }
            set { SetValue(QuestionsProperty, value); }
        }
        public static readonly DependencyProperty QuestionsProperty =
            DependencyProperty.Register("Questions", typeof(List<QuestionAndAnswers>), typeof(QuestionnaireControl));
        public ObservableCollection<Answer> Answers
        {
            get { return (ObservableCollection<Answer>)GetValue(AnswersProperty); }
            set { SetValue(AnswersProperty, value); }
        }
        public static readonly DependencyProperty AnswersProperty =
            DependencyProperty.Register("Answers", typeof(ObservableCollection<Answer>), typeof(QuestionnaireControl), new FrameworkPropertyMetadata(null));
    }
