    //Find it however you can in the context
    var existing = _countryLanguageQuestionRepository.GetById(id);
    
    if (existing == null){
         var clq = new CountryLanguageQuestion
             {
                 CountryId = s.CountryId,
                 LanguageId = languageId,
                 QuestionNumber = questionNum,
                 SurveyQuestionId = s.SurveyQuestionId,
                 QuestionText = s.QuestionText
             };
         _countryLanguageQuestionRepository.Add(clq);
    } else {
     //Update existing object and save it
    }
