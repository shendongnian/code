    @foreach (var item in Model.ControlInformations)
        {
            if (@item.ControlType == "System.Int32")
            {
                Html.RenderPartial("IntCtrl", item);
            }
            else
            {
                Html.RenderPartial("StringCtrl", item);
            }
        }
