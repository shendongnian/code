    <thead>
        <tr>
            <th></th>
            @foreach(var heading in Model.Headings)
            {
                <th>@heading</th>
            }
        </tr>
    </thead>
    <tbody>
        @for(int i = 0; i < Model.Rows.Count; i++)
        {
            <tr>
                <td>
                    @Html.HiddenFor(m => m.Permissions[i].Right)
                    @Html.DisplayFor(m => m.Permissions[i].Right)
                </td>
                @for(int j = 0; j < Model.Permissions[i].Groups.Count; j++)
                {
                    <td>
                        @Html.HiddenFor(m => m.Permissions[i].Groups[j].GroupID)
                        @Html.CheckboxFor(m => m.Permissions[i].Groups[j].IsSelected)
                    </td>
                }
            </tr>
        }
    </tbody>
