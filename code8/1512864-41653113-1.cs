    @{
        if(ViewBag.User_Has_Products != null)
        {
            foreach(var item in ViewBag.User_Has_Products)
            {
                <p>@item.name</p>
            }
        }
    }
