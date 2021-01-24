    @{
        ViewBag.Title = "Comments";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
        
        
    @foreach (var item in Model) {
    @Html.DisplayFor(ModelItem => item.Article.Title)
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.Comments.ic_comment)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Comments.ic_crtdte)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Comments.ic_pcname)
        </td>
        <td
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.ic_id }) |
            @Html.ActionLink("Details", "Details", new { id=item.ic_id }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.ic_id })
        </td>
    </tr>
    }
