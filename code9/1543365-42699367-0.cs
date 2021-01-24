    foreach(var question in qbs.Questions)
    {
        int switchKey = (question.QuestionIndex - 300) % 4;
        switch (switchKey)
        {
            case 0:
                Funding = new ExpandoObject();
                Funding.Revenue_Code = question.ANSWER_LOOKUP_OPTION_NAME;
                formData.Fundings.Add(Funding);
                break;
            case 1:
                Funding = new ExpandoObject();
                Funding.Funding_Source = question.ANSWER_STRING;
                formData.Fundings.Add(Funding);
                break;
            case 2:
                Funding = new ExpandoObject();
                Funding.Amount = question.ANSWER_FLOAT;
                formData.Fundings.Add(Funding);
                break;
            case 3:
                Funding = new ExpandoObject();
                Funding.Percent_Of_Funding = question.ANSWER_FLOAT / 100;
                formData.Fundings.Add(Funding);
                break;
        }
    }
