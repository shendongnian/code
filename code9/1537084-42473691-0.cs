    private int freezeScore;
    private int score;
    private void Update()
    {
        if (score >= freezeScore)
        {
            StartQuiz();
        }
    }
    public void StartQuiz()
    {
        Time.timeScale= 0;
        if (canvasquiz != null)
        {
            canvasquiz.SetActive(true);
        }
    }
    //Attatch to button
    public void EndQuiz()
    {
        if (canvasquiz != null)
        {
            canvasquiz.SetActive(false);
            Time.timeScale = 1.0f;
        }
        score += 1;
        freezeScore += 200;
    }
