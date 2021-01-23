       List<Quiz> lstQuiz = new List<Quiz>();
        int limit = 5;
        protected void btn_Click(object sender, EventArgs e)
        {
            btn.Enabled = (lstQuiz.Count >= limit)?false:true;
            lstQuiz.Add(new Quiz());
        }
