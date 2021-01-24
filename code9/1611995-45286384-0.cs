    foreach (var dv in Model.DisplayValues)
            {
                @:<tr>
                    <td>@dv.PropertyDisplayName</td>
                    <td>
                    switch (dv.Type)
                    {
                        case DisplayValueType.Decimal:
                        case DisplayValueType.String:
                        case DisplayValueType.Other:
                        @Html.Editor("Item."+dv.PropertyName);
                        case DisplayValueType.PickList:
                        @Html.DropDownList("Item."+dv.PropertyName,EnumHelper.GetSelectList(Model.Item.GetType().GetProperty(dv.PropertyName).PropertyType));
                                                                                      break;
                    }
                    @:
                </td>
            </tr>
                }
