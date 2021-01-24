    public QuestionTwoScreen(string name = String.Empty, int quizSelection = 0)
        {
            InitializeComponent();
            CenterToScreen();
            ScoreLbl.Text = "Score: " + StartScreen.Player.Score;
            SetupQuiz(name,quizSelection);
        }
