    @for (var i = 0; i < Model.Questions.Count; i++)
    {
        <p>@Model.Questions[i].QuestionText</p>
        
        @for (var j = 0; j < Model.Questions[i].Answers.Count; j++)
        {
            <label>
                <input asp-for="Questions[i].SelectedAnswers" type="radio" value="@Model.Questions[i].Answers[j].Id" />
                @Model.Questions[i].Answers[j].AnswerText
            </label>
        }
    }
