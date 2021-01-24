    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MoveNextQuestion();
            timerAnswer.Interval = 5000;
            timerAnswer.Start();
        }
        private string[] _questionsAndAnswers = new[]
        {
            "What colour is the sky?",
            "Blue",
            "What do chickens lay?",
            "Eggs",
        };
        private int _currentIndex = -2;
        private void timerAnswer_Tick(object sender, EventArgs e)
        {
            MoveNextQuestion();
        }
        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            MoveNextQuestion();
        }
        private void MoveNextQuestion()
        {
            _currentIndex += 2;
            if (_currentIndex < _questionsAndAnswers.Length)
            {
                labelQuestion.Text = _questionsAndAnswers[_currentIndex];
            }
            else
            {
                timerAnswer.Stop();
            }
        }
    }
