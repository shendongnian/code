    @model UberUnlock.ViewModel.MultipleModelInOneView
                    <dd>
                        @using (Html.BeginForm("AddToBasket", "Basket", new { id = Model.Products.ID,quantity = quantityvalue }))
                        {
                            @Html.AntiForgeryToken()
                            @Html.HiddenFor(model => model.Products.ID)
                            @Html.DropDownList("quantity", Enumerable.Range(1, 10).Select(i => new SelectListItem { Text = i.ToString(), Value = i.ToString() }))
                            <input type="submit" class="btn btn-primary btn-default margin" value="Add to Basket">
                        }
                    </dd>
    <p>
    @Html.ActionLink("Edit", "Edit", new { id = Model.Products.ID }) |
    @Html.ActionLink("Back to List", "Index")
    </p>  
