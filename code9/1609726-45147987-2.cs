    @model ICollection<WebApplication2.Models.Test>
    
    @{
        ViewBag.Title = "Home Page";
    }
    
    @using (Html.BeginForm("Index", "Home", FormMethod.Post))
    {
        @Html.EditorFor(x => x)
        <input id="btnSubmit" type="submit" value="Submit" />
    }
