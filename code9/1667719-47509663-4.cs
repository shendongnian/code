    // <table> etc...
    @using (Html.BeginForm("PostCards", "CustomerView", FormMethod.Post) {
        @for (var i = 0; i < Model.Count; i++) {
            @{ var item = Model.ElementAt(i); }
            <tr>
                <td>
                    @Html.Hidden("CardId[" + i + "]")
                    @Html.CheckBox("IsSelected[" + i + "]")
                </td>
                // display other properties of item ...
                <td>@item.CardID</td>
                // ...
            </tr>
        }
        <button type="submit">Load Cards</button>
    }
