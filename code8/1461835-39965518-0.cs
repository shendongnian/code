    @for (int i = 0; i < Model.GameAssignerTable.Count(); i++)
    {
       
        <tr>
            <td>
                @Model.GameAssignerTable[i].GameName
                @Html.HiddenFor(m => m.GameAssignerTable[i].GroupGameId)
        </td>
           
            <td>
                @Html.EditorFor(m => m.GameAssignerTable[i].IsAssigned)
            </td>
            <td>
                @Html.TextBoxFor(m => m.GameAssignerTable[i].UnAssignedDate, new {id = "UnassignedDate" + i})
            </td>
        </tr>
    }
