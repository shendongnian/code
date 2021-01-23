    @{ int testCounter = 0; int nestedQuestionsCounter = 0; }
    @foreach (var questionGroups in Model.ClientQuestionGroups)
    {
        
            for (var j = 0; j < questionGroups.Questions.Count; j++)
            {       
            <div class="@(testCounter)test">
                @Html.HiddenFor(m => m.QuestionAnswers[j].FormAnswerId)
                @Html.HiddenFor(m => m.QuestionAnswers[j].QuestionId)
                @foreach (var alternative in questionGroups.Questions[j].QuestionAlternatives)
                {
                    if (alternative.NestedQuestion != null)
                    {
                       nestedQuestions.Add(alternative.NestedQuestion);
                    }
                }
            </div>
                
        }
    
        if (nestedQuestions.Count > 0)
        {
            nestedQuestionsCounter = 1;
            for (var i = 0; i < nestedQuestions.Count; i++)
            {
                <div class="@(nestedQuestionsCounter)nestedQuestion">
                    @Html.HiddenFor(m => m.QuestionAnswers[i].FormAnswerId)
                    @Html.HiddenFor(m => m.QuestionAnswers[i].QuestionId)
                    @foreach (var alt in nestedQuestions[i].QuestionAlternatives)
                    {
                       @Html.DisplayFor(m => alt.AlternativeText)
                       @Html.RadioButtonFor(m => m.QuestionAnswers[i].AlternativeId, alt.Id, new { @class = "questionAlternative" });
                    }
                </div>
                nestedQuestionsCounter++;
             }
        }
        testCounter++;
    }
