    @model AdminViewModel
    
    using (Html.BeginForm("EditTemplate", "Config", FormMethod.Post, new { @class = "form-horizontal" }))
    {
        for (var i = 0; i < Model.Templates.Count; i++)
        {
            <div class="form-group">
            @if (Model.Templates[i].JobID != null)
            {
                @Html.LabelFor(m => m.Templates[i].Description)
                @Html.TextBoxFor(m => m.Templates[i].Description)
    
                @Html.LabelFor(m => m.Templates[i].Weight)
                @Html.TextBoxFor(m => m.Templates[i].Weight)
    
                @Html.HiddenFor(m => m.Templates[i].ID)
                @Html.HiddenFor(m => m.Templates[i].JobID)
                <br />@Html.ActionLink("Delete", "DeleteTemplate", new { id = @Model.Templates[i].ID, jobID = selectedJobID })
            }
    
            </div>
        }
        <input type="submit" value="Update" class="btn btn-success" id="editSubmit" />
    }
    
    using (Html.BeginForm("EditCompetency", "Config", FormMethod.Post, new { @class = "form-horizontal" }))
    {
        for (var i = 0; i < Model.Competencies.Count; i++)
        {
            <div class="form-group">
                @if (Model.Competencies[i].JobID == null)
                {
                    @Html.LabelFor(m => m.Competencies[i].Description)
                    @Html.TextBoxFor(m => m.Competencies[i].Description)
    
                    @Html.LabelFor(m => m.Competencies[i].Weight)
                    @Html.TextBoxFor(m => m.Competencies[i].Weight)
    
                    @Html.HiddenFor(m => m.Competencies[i].ID)
                    @Html.HiddenFor(m => m.Competencies[i].JobID)
                    <br />@Html.ActionLink("Delete", "DeleteCompentency", new { id = @Model.Competencies[i].ID})
                }
    
            </div>
        }
        <input type="submit" value="Update" class="btn btn-success" id="editSubmit" />
    
    }
