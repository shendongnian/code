    @using MVCOnlineShop.Models;
    @*[anything you want here]*@
    @{
        // stores the Session content in a var
        var Categories = Session["Categories"] as List<Category>;
    }
    
    @*Checks if the Session variable is correct*@
    @if(Categories != null){
        <ul>
            @*For each category in the Session var, display the link*@
            @foreach(var Category in Categories){
                <li>
                    @Html.ActionLink(Category.CategoryName, "Browse", new { Category = Category.CategoryName })
                </li>
            }
        </ul>
    }
