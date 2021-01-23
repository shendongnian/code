    private string _student;
    public string Student
    {
        get { return _student; }
        set { if(value.Length <= 20) _student = value;
    }
