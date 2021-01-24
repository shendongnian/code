    @for (int i = 0; i < Model.AmericanStates.Count(); i++)
    {
        {
            // change the "selected" buyer to match the buyer Id for this state
            var selectedOption = Model.buyerDropdown.Single(x => x.Value == Convert.ToString(state.Buyer.Id)).FirstOrDefault();
        }
        <tr>
    		// Other controls
            <td>@Html.DropDownListFor(model => model.AmericanStates[i].selectedBuyer, new SelectList(Model.buyerDropdown, "Key", "Value", selectedOption), new { @class = "form-control" })</td>
            <td></td>
        </tr>
    }
