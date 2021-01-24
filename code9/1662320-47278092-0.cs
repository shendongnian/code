    @{
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
    }
    <head>
        ...
    </head>
    <body>
    @if (user != null)
    {
        <a href="/user/edit/?username=@user.UserName" class="dropdown-toggle">
            <span class="hidden-xs">@user.FullName</span>
        </a>
    }
    </body>
