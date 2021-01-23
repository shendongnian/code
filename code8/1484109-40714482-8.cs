        @foreach (var item in Model)
    {
    for (int i = 0; i < @item.Contatti.Count(); i++)
    {
      <tr>
        <td>
            @item.Contatti[i].Nome
            @item.Contatti[i].Citta
            @item.Contatti[i].ContattoID
            @item.Contatti[i].CodicePostale
            @item.Contatti[i].Email
            @item.Contatti[i].Address
            @item.Contatti[i].CompanyId
            @item.Contatti[i].ContactId
            @item.Contatti[i].CompanyName
         
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.Contatti[i].ContattoID }) |
            @Html.ActionLink("Details", "Details", new { item.Contatti[i].ContattoID }) |
            @Html.ActionLink("Delete", "Delete", new { item.Contatti[i].ContattoID })
        </td>
    </tr>
      }
     }
