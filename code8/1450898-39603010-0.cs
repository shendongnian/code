        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Random randomNum = new Random();
                randNum = randomNum.Next(0, 10);
                ViewState["randNum"] = randNum;
            }
            else
            {
                randNum = (int) ViewState["randNum"];
            }
            Label1.Text = "Guessing game! Guess a number between [0,10) to see if you can get it right!";
        }
