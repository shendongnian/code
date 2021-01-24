    @model AddOfferAnnounceModel
    @using(Html.BeginForm())
    {
       @Html.TextBoxFor(a=>a.Price)
       @Html.TextBoxFor(a=>a.Surface)
       @Html.TextBoxFor(a=>a.AnnounceDetails)
       @Html.DropDownListFor(a=>a.SelectedItem,Model.Items)
       <input type="submit" />
    }
