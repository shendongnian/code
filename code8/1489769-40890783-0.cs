    @model IEnumerable<ApproveItemViewModel>
    @for (int i = 0; i < Model.Count; i++)
    {
        using (Ajax.BeginForm("ApproveItem", new AjaxOptions()
                            {
                                InsertionMode = InsertionMode.Replace,
                                HttpMethod = "POST",
                                UpdateTargetId = "dane"
                            }))
        {
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(true)
    
            <table>
                <tr>
                    <td>@Html.LabelFor(m => Model[i].ItemId)</td>
                    <td>@Html.DisplayFor(m => Model[i].ItemId)</td>
                </tr>
                <tr>
                    <td>@Html.LabelFor(m => Model[i].ItemCode)</td>
                    <td>@Html.TextBoxFor(m => Model[i].ItemCode))</td>
                </tr>
                <tr>
                    <td><input type="submit" value="Approve" /></td>
                </tr>
            </table>
        }
    }
