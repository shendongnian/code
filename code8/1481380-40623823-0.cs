    List<Quiz> quizzes = new List<Quiz>();
    int limit = 5;
    private void btnAdd_Click(object sender, EventArgs e)
    { 
        if (quizzes.Count >= limit) {
            btn.Add.Enabled = false;
        } else {
            quizzes.Add(new Quiz("abc"));
        }
    }
