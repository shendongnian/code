       @model IEnumerable<Testing.Models.ProductItem>
       @{
           ViewBag.Title = "Buy Products";
        }
    
        <div class="row">
        using (Html.BeginForm())
        {
           @foreach (var product in Model)
           {
                 @Html.HiddenFor(p => product.ID)
                 @Html.TextBox("qty", "1", htmlAttributes: new { @style = "width: 
               30px;" })
    
                ... More Controls and stuff...         
    
            }
            <input type="submit" value="Add To Kart" class="btn btn-info">
        }
        </div>
