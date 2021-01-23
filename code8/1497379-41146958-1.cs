    @if (User.Identity.Name == item.email)
    {
    	@Html.ActionLink("Edit", "Edit", new { id = item.PersonId })
    	<text> | </text>
    	@Html.ActionLink("Delete", "Delete", new { id = item.PersonId })
    }
