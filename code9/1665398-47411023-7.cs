    //Let's say a user has lots of names
    public class User
    {
        public int Id { get; set; }
        public List<string> Names { get; set; }
    }
    //View:
    @model User
    @Html.TextBoxFor(m => m.Id)
    @foreach (var name in Model.Names)
    {
        <div>@name</div> 
    }
