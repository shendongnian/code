                                  @{
                                       var i = 1; @*sr no will start from 1*@
                                    }
                                    <table class="table">
                                        <tr>
                                            <th>Sr No.</th>
                                            <th>
                                                @Html.DisplayNameFor(model => model.Name)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(model => model.ModifiedDate)
                                            </th>
                                            <th></th>
                                        </tr>
    
                                        @foreach (var item in Model)
                                        {
                                            <tr>
                                                <td>
                                                    <span>@i</span>
                                                </td>
                                                <td>
                                                    @Html.DisplayFor(modelItem => item.Name)
                                                </td>
                                                <td>
                                                    @Html.DisplayFor(modelItem => item.ModifiedDate)
                                                </td>
                                                <td>
                                                    @Html.ActionLink("Edit", "Edit", new { id = item.CurrencyCode }) |
                                                    @Html.ActionLink("Details", "Details", new { id = item.CurrencyCode }) |
                                                    @Html.ActionLink("Delete", "Delete", new { id = item.CurrencyCode })
                                                </td>
                                            </tr>
                                            i++;
                                        }
