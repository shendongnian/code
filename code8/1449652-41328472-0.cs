    // GET: /Manage/Index
    [AuthorizePermission(Name = "Show_Management", Description = "Show the Management Page.")]
    public async Task<ActionResult> Index(ManageMessageId? message)
    {
        //...
    }
