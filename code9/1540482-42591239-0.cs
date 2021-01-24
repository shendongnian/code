    Public int StudentID {get; set;}
    public Test(string studentID)
    {
    InitializeComponent();
    StudentID = Convert.ToInt32(studentID);
    }
