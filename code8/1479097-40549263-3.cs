    <table>
        @for (int i = 0; i < Model.Array.GetLength(0); i++)
        {
            <tr>
                @for(int j=0;j<Model.Array.GetLength(1);j++)
                {
                    <td>
                        @Model.Array[i, j]
                    </td>
                }
            </tr>
        }
    </table>
