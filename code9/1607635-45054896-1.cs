    @if(Session["Categories"] != null){
        <ul>
            @foreach(var Category in Session["Categories"] as List<MVCOnlineShop.Models.Category>){
                <li>
                    @Html.ActionLink(Category.CategoryName, "Browse", new { Category = Category.CategoryName })
                </li>
            }
        </ul>
    }
