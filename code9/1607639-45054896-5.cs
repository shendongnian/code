    @using MVCOnlineShop.Models;
    @*[anything you want here]*@
    @*Check if the Session variable exists*@
    @if(Session["Categories"] != null){
        <ul>
            @*For each category in the Session var, display the link*@
            @foreach(var Category in Session["Categories"] as List<Category>){
                <li>
                    @Html.ActionLink(Category.CategoryName, "Browse", new { Category = Category.CategoryName })
                </li>
            }
        </ul>
    }
