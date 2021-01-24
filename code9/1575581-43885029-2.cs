    @using MyWebProject.DataModels
    @using System.Dynamic
    @model dynamic
    @{
        ViewBag.Title = "Test";
    }
     
    <form>
    
        @Html.MyTextBox((CustomModelEditor)Model.Name)
        @Html.MyTextBox((CustomModelEditor)Model.Email)
        <button type="submit">test</button>
    </form>
