    @foreach (American_States state in Model.AmericanStates)
    {
        {
            int selectedOptionInt;
            // change the "selected" buyer to match the buyer Id for this state
            var selectedOption = Model.buyerDropdown.Single(x => x.Value == Convert.ToString(state.Buyer.Id)).FirstOrDefault().Value;
            var isNumber = Int32.TryParse(selectedOption, selectedOptionInt);
        }
        <tr>
            <td>@state.name</td>
            <td>@state.Title.OfficerName</td>
            <td>@Html.DropDownListFor(model => model.selectedBuyer, new SelectList(Model.buyerDropdown, "Key", "Value", selectedOptionInt), new { @class = "form-control" })</td>
            <td></td>
        </tr>
    }
