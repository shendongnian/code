    private bool _answerSelected;
    public bool AnswerSelected
    {
        get
        {
            return _answerSelected;
        }
        set
        {
            _answerSelected = value;
            OnPropertyChanged("AnswerSelected");
        }
    }
