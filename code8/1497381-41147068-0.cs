    <td>
        @if (User.Identity.Name == item.email)
        {
            <div>
                @Html.ActionLink("Edit", "Edit", new { id = item.PersonId })
                |
                @Html.ActionLink("Delete", "Delete", new { id = item.PersonId })
            </div>
        }
    </td>
