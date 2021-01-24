    public List<Question> GetDirectChildren(Question question) 
    {
        var children = new List<Question>();
    
        if (question.Links.Count > 0)
        {
            foreach(Link link in question.Links)
            {
                Question curQuestion = myQuestions.FirstOrDefault(f => f.ID == link.QuestionID);
                children.Add(curQuestion);
                children.AddRange(GetDirectChildren(curQuestion));
            }
        }
        else
            return children;
    }
