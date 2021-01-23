     @if (subPages.Count() > 0)
        {
            <ul>
                @foreach (var subPage in subPages)
                {
                    var genderQuery = Request.QueryString.Get("gender");
    
                    if (subPage.Children.Count() > 0 &&
                        ( genderQuery == null || 
                subPage.GetPropertyValue<bool>("gender") == bool.Parse(genderQuery)))
                    {
                        <li class="child @(CurrentPage.Name == subPage.Name ? currentClass :"")">
    
                            <a href="@subPage.Url">@subPage.Name </a>
                            <a href="@subPage.Parent.Parent.Url" class="@(CurrentPage.Name == subPage.Name ? currentClass : "hide")"><i class="fa fa-close"></i></a>
                        </li>
                    }
                }
            </ul>
        }
