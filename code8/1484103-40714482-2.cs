        @foreach (var item in Model)
    {
    for (int i = 0; i < @item.Contatti.Count(); i++)
    {
      <tr>
        <td>
            @Html.DisplayFor(modelItem => item.Contatti.Nome)
            @Html.DisplayFor(modelItem => item.Contatti.Citta)
            @Html.DisplayFor(modelItem => item.Contatti.ContattoID)
            @Html.DisplayFor(modelItem => item.Contatti.CodicePostale)
            @Html.DisplayFor(modelItem => item.Contatti.Email)
            @Html.DisplayFor(modelItem => item.Contact.Address)
            @Html.DisplayFor(modelItem => item.Contact.CompanyId)
            @Html.DisplayFor(modelItem => item.Contact.ContactId)
            @Html.DisplayFor(modelItem => item.Company.CompanyName)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.ContattoID }) |
            @Html.ActionLink("Details", "Details", new { id=item.ContattoID }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.ContattoID })
        </td>
    </tr>
      }
     }
