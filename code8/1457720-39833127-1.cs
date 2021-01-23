    private int idMode;
    public Text question;
    public Text answerA;
    public Text answerB;
    public Text answerC;
    public Text answerD;
    public Text infoAnswer;
    public Text stat;
    public Quesetion[] questions;
    private int idQuestion; 
    private float points;
    private float fact; 
    private float average;
    private int results;
    
    void Start () {
        idMode = PlayerPrefs.GetInt ("idMode");
        idQuestion = 0;
        fact = questions.Length;
        questions.Shuffle();
        question.text = questions[idQuestion].Text;
        answerA.text = questions[idQuestion].A;
        answerB.text = questions[idQuestion].B;
        answerC.text = questions[idQuestion].C;
        answerD.text = questions[idQuestion].D;
        infoAnswer.text = (idQuestion + 1).ToString() + " of " + fact.ToString () + "";
    }
    public void answer(string alternative)
    {
        if (alternative == questions[idQuestion].CorrectChoice) 
        {
            points += 1;
        }
    
        nextQuestion ();
    } 
    void nextQuestion()
    {
        idQuestion += Random.Range(0,10);
        if(idQuestion <= (fact-1))
        {
            question.text = questions[idQuestion].Text;
            answerA.text = questions[idQuestion].A;
            answerB.text = questions[idQuestion].B;
            answerC.text = questions[idQuestion].C;
            answerD.text = questions[idQuestion].D;
            stat.text = " Correct: " + points.ToString () + "";
            infoAnswer.text =  (idQuestion + 1).ToString() + " of " + fact.ToString () + "";
        }
        else
        {
            average = 10 * (points / fact);
            results = Mathf.RoundToInt (average);
            if (results > PlayerPrefs.GetInt ("results" + idMode.ToString ())) {
                PlayerPrefs.SetInt ("results" + idMode.ToString (), results);
                PlayerPrefs.SetInt ("points" + idMode.ToString (), (int)points);
            }
            PlayerPrefs.SetInt ("resultsTemp" + idMode.ToString (), results);
            PlayerPrefs.SetInt ("pointsTemp" + idMode.ToString (), (int)points);
            Application.LoadLevel("results");
        }
    }
