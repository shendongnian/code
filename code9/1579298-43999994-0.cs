    protected void nextBtn_Click(object sender, EventArgs e)
    {
        int questions = Session["questions"] ==null? 1:
           Convert.ToInt32(Session["questions"]);        
        questions++;
        Session["questions"] = questions;
        qstnLbl.Text = questions.ToString();
    }
