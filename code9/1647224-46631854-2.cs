    @model MyProject.Web.Models.IdentityRoleView
    @{
        ViewBag.Title = "Edit";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    
    @using (Html.BeginForm())
    {
        @Html.ValidationSummary(true)
        @Html.HiddenFor(model => model.Id);
        <div>
            Role name
        </div>
            <p>
                @Html.TextBoxFor(model => model.Name)
            </p>
    
    for (int i = 0; i < Model.Users.Count(); i++)
    {
        @Html.TextBoxFor(model => model.Users[i].Email)
        @Html.TextBoxFor(model => model.Users[i].UserName)
    
    }
    
                <input type="submit" value="Save" />
    }
