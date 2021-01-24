    @model ICollection<string>    
    @{
        ViewBag.Title = "Home Page";
    }
    
    @using (Html.BeginForm("Index", "Home", FormMethod.Post)) {
        @for(int index = 0; index < Mode.Count; i++) {
            @Html.EditorFor(x => x[index])
        }
        <input id="btnSubmit" type="submit" value="Submit" />
    }
