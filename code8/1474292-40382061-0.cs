    if (nestedQuestions.Count > 0)
    {
        for (var i = 0; i < nestedQuestions.Count; i++)
        {
            <div class="nestedQuestion">
                @Html.Hidden("NestedQuestions", Model.QuestionAnswers[i].FormAnswerId)
                 @Html.Hidden("NestedQuestions", Model.QuestionAnswers[i].QuestionId)
                @foreach (var alt in nestedQuestions[i].QuestionAlternatives)
                {
                   @Html.Display("NestedQuestion", alt.AlternativeText)
                   @Html.RadioButton("NestedQuestion", m.QuestionAnswers[i].AlternativeId, alt.Id, new { @class = "questionAlternative" });
                }
            </div>
         }
    }
