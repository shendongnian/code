    @model IList<TRecord>
    
    @using (Html.BeginForm())
    {
        // display names area
    
        @for (var i = 0; i < Model.Count; i++)
        {
            <tr>
                <td>
                    @Html.DisplayFor(item => item[i].Tid)
                </td>
                <td>
                    @Html.EditFor(item => item[i].Tname)
                </td>
            </tr>
        }
    
        // submit button area
    }
