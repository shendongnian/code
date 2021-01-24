    @using (Html.BeginForm("Step6", "Home", FormMethod.Post))
    {
        @Html.HiddenFor(m => m.EventID)
        @Html.HiddenFor(m => m.CompanyID)
        for( Int32 i = 0; i < this.Model.Questions.Count; i++ )
        {
        <div class="checkbox">
            @Html.CheckBoxFor( m => m.Questions[i].Selected )
            @Html.LabelFor( m => m.Questions[i].Selected, this.Model.Questions[i].Title )
        </div>
        }
        <p><input type="submit" class="btn btn-primary" value="Submit" /></p>
    }
