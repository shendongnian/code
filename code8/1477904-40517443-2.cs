    public _repository.tbl_TestQuestion questionList;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["question"] == null)
        {
            questionList = _repository.tbl_TestQuestion
                .Where(x => x.nCourseId == courseId && x.nChapterId == chapterId && x.bActive == true)
                .OrderBy(x => Guid.NewGuid()).Take(10).ToList();
    
            Session["question"] = questionList;
        }
        else
        {
            questionList = Session["question"] as _repository.tbl_TestQuestion;
        }
    }
