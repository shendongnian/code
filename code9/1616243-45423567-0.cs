    @model List<ShoppingKartTest.Models.ProductItem>
    @{
        ViewBag.Title = "Buy Products";
    }
    
    
    
    @foreach (var item in Model)
    {
        using (Html.BeginForm())
        {
    
           <input type="hidden" value="@item.ID" name="ID" />
           @Html.TextBox("qty", "1", new { @style = "width: 30px;" })
    
    
           <input type="submit" value="Add To Kart" class="btn btn-info">
        }
    }
