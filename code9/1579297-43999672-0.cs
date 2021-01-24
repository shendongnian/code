    protected void nextBtn_Click(object sender, EventArgs e)
    {
        questions = 1;
        if (Session["questions"] != null)
           questions = (int)Session["questions"];
        questions++;
        Session["questions"] = questions;
        qstnLbl.Text = questions.ToString();
    }
