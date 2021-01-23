    @if (Model.IsReadOnly)
    {   
        <fieldset disabled="disabled">
            @FormContent()
        </fieldset>
    }
    else
    {
        @using (Html.BeginForm("Edit", "HomeController"))
        {
            @Html.AntiForgeryToken()
    
            @FormContent()
    
            <input type="submit" id="submitButton" />
        }
    }
