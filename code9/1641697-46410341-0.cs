    @using (Html.BeginForm())
    {
        <table>
            @for (int column = 0; column < Model.Data.Length; column++)
            {
                <tr>
                    @for (int row = 0; row < Model.Data[column].Length; row++)
                    {
                        <td>@Html.EditorFor(x => Model.Data[column][row])</td>
                    }
                </tr>
            }
        </table>
        <button type="submit">Submit</button>
    }
