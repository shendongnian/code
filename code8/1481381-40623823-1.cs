    List<Quiz> quizzes = new List<Quiz>();
    int limit = 5;
    private void btnAdd_Click(object sender, EventArgs e)
    { 
        var isEnabled = (quizzes.Count < limit);
        If (isEnabled) { quizzes.Add(new Quiz("abc")); } 
        isEnabled = (quizzes.Count < limit);
        btn.Add.Enabled = isEnabled;
        
    }
