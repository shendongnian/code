    if (User.IsInRole("Tenant"))
    {
        Layout = "~/Views/Shared/_LoggedTenantLayout.cshtml";
    }
    else if (User.IsInRole("Owner"))
    {
        Layout = "~/Views/Shared/_LoggedInOwnerlayout.cshtml";
    }
    else
    {
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
