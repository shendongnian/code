    @{
    var menuModel = new NewWebsite_SITE_2018.Pages.View.ViewBar_Info.MenuModel();
    }
    
    @foreach (var item in menuModel.GetListMenu)
    {
        <a>@item.Name</a>
    }
