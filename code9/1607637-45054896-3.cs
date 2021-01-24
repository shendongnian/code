    @using MVCOnlineShop.Models;
    [...]
    @if(Session["Categories"] != null){
        <ul>
            @foreach(var Category in Session["Categories"] as List<Category>){
                <li>
                    @Html.ActionLink(Category.CategoryName, "Browse", new { Category = Category.CategoryName })
                </li>
            }
        </ul>
    }
