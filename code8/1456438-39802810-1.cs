    @model List<UserVM>
    ....
    @using (Html.BeginForm())
    {
        <table>
            <thead>....</thead>
            <tbody>
                @for(int i = 0; i < Model.Count; i++)
                {
                    <tr>
                        <td>
                            @Html.DisplayFor(m => m[i].UserName)
                            @Html.HiddenFor(m => m[i].UserName)
                        </td>
                        @for(int j = 0; j < Model[i].Roles.Count; j++)
                        {
                            <td>
                                @Html.HiddenFor(m => m[i]Roles[j].RoleName)
                                @Html.CheckBoxFor(m => m[i]Roles[j].IsSelected)
                            </td>
                        }
                    </tr>
                }
            </tbody>
        </table>
        <input type="submit" ... />
    }
