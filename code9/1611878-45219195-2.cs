     @*Top Sort Span Buttons *@
        @if(Model.Context != null && Model.Sort == TestSite.Domain.Models.SortAlgorithm.Top)
        {
            < div >
                < ul class="tabmenu submenu">
                    @{
                        var spans = new SortSpan[] { SortSpan.Day, SortSpan.Week, SortSpan.Month, SortSpan.Quarter, SortSpan.Year, SortSpan.All };
                        Type type = typeof(SortSpan);
                        foreach (var span in spans)
                        {
                            MemberInfo[] memberInfo = type.GetMember(span.ToString());
                            object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                            string name = ((DisplayAttribute)attributes[0]).Name;
                            <li class='@(Model.Span.HasValue && Model.Span.Value == span ? "selected" : "disabled")'>@Html.RouteLink(name, Model.Submissions.RouteName, new { sort = (Model.Sort == null ? "" : Model.Sort.ToString().ToLower()), span = name.ToLower() })</li>
                        }
                    }
                </ul>
            </div>
        }
