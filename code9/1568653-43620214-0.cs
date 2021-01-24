    foreach (int i = 0; i < Model.Count; i++)
    {
        @Html.DisplayFor(model => Model[i].QuestionTx)
        @Html.HiddenFor(model => Model[i].Id)
        @Html.HiddenFor(model => Model[i].QuestionTx)
        <br/>
        <br/>
        foreach (int j = 0; j < Model[i].ClassTestQuestionMc; j++)
        {
            @Html.DisplayFor(model => Model[i].ClassTestQuestionMc[j].AnswerTx)
            @Html.HiddenFor(model => Model[i].ClassTestQuestionMc[j].AnswerTx)
            @Html.CheckBoxFor(model => Model[i].ClassTestQuestionMc[j].IsChecked)
            @Html.HiddenFor(model => Model[i].ClassTestQuestionMc[j].IsChecked)
        }
    }
