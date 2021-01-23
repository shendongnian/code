    @using (Html.BeginForm("TransposeMatrix", "Home", FormMethod.Post, null))
    {
        <table>
            @for (int row = 0; row < Model.Rows; row++)
            {
                <tr>
                    @for (int column = 0; column < Model.Columns; column++)
                    {
                        <td>@Model.Matrix[row, column]</td>
                    }
                </tr>
            }
        </table>
    
        @Html.HiddenFor(model => model.Rows)
        @Html.HiddenFor(model => model.Columns)
        @Html.HiddenFor(model => model.Matrix)
        <input type="submit" value="Transpose" />
        You are using FormExtensions.BeginForm Method (HtmlHelper, String, String, FormMethod, Object), where object is for the HTML attributes to set for the element. Currently it is setting the id of the form tag.
