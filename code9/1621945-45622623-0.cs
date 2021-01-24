    @for(int i=0; i<Model.CuttomersOrders.Count(); i++)
    {
      <tr>
        <td>
        @if (!String.IsNullOrEmpty(Model.CuttomersOrders[i].CustName))
        {
            @Html.TextBoxFor(c => c.CuttomersOrders[i].CustName,new { @readonly=true})
        }
        else
        {
            @Html.TextBoxFor(c => c.CuttomersOrders[i].CustName)
        }
        </td>
      </tr>
    }
