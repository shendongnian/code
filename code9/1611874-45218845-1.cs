    <ul class="tabmenu submenu">
        @{    
            foreach (SelectListItem span in EnumHelper.GetSelectList(typeof(SortSpan)))
            {
                <li class='@(Model.Span.HasValue && Model.Span.Value == span.Value ? "selected" : "disabled")'>
                    @Html.RouteLink(span.Text, Model.Submissions.RouteName, new { sort = (Model.Sort == null ? "" : Model.Sort.ToString().ToLower()), span = span.Text.ToLower() })
                </li>
            }
        }
    </ul>
