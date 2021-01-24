    public PartialViewResult _CreateComment(int orderId, int orgId)
    {
        var viewModel = new NewCommentViewModel()
        {
            OrderId = orderId,
            OrganisationId = orgId,
            UserId = User.Identity.GetUserId()
        };
        return PartialView(viewModel);
    }
