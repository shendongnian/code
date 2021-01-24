    public partial class MainWindow : Window
    {
        Timer answerTimeTimer; // it's for counting time of answer
        Timer questionTimer; // this is used for generating questions
        int timeOfAnswer;
        public MainWindow()
        {
            InitializeComponent();
            questionTimer = new Timer()
            {
                Interval = 2500
            };
            answerTimeTimer = new Timer()
            {
                Interval = 1000 
            };
            answerTimeTimer.Elapsed += AnswerTimeTimer_Elapsed;
            questionTimer.Elapsed += QuestionTimer_Elapsed;
            questionTimer.Start();
        }
        private void QuestionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            AskQuestion();
        }
        private void AskQuestion()
        {
            //Your questions logic
            Console.WriteLine("Question asked");
            Dispatcher.Invoke(new Action(() => label.Content = "Question asked")); // This line is just to update the label's text (it's strange because you need to update it from suitable thread)
            answerTimeTimer.Start();
            questionTimer.Stop();
        }
        private void AnswerTimeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timeOfAnswer++;
            Dispatcher.Invoke(new Action(() => label.Content = timeOfAnswer));
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left || e.Key == Key.Right)
            {
                if (answerTimeTimer.Enabled)
                {
                    answerTimeTimer.Stop();
                    //Here you can save the time from timeOfAnswer
                    Console.WriteLine("Question answered in " + timeOfAnswer);
                    Dispatcher.Invoke(new Action(() => label.Content = "Question answered in " + timeOfAnswer));
                    timeOfAnswer = 0; // Reset time for the next question
                    questionTimer.Start();
                    
                }
            }
        }
    }
