    @model SurveyResponseVM
    ....
    @using (Html.BeginForm())
    {
        @Html.DropDownListFor(m => m.SelectedArea, Model.AreaList)
        ....
        for(int i = 0; i < Model.Questions.Count; i++)
        {
            <h3>@Model.Questions[i].QuestionText</h3>
            @Html.HiddenFor(m => m.Questions[i].AnswerID)
            for (int j = 0; j < 6; j++)
            {
                <label>
                    @Html.RadioButtonFor(m => m.Questions[i].Resonse, j, new { id = "" })
                    <span>@j</span>
                </label>
            }
        }
        <input type="submit" value="Save" />
    }
