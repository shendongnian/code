    @{
        dynamic m1 = new { MenuName = "name1" };
        dynamic m2 = new { MenuName = "name2" };
        IEnumerable<dynamic> Model = new[] { m1, m2 };
    }
    
    @foreach (dynamic item in Model)
    {
        <span>@item.MenuName</span>
    }
