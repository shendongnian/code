    @model  WebApplication1.Models.ViewModelProductsMain
    
    @{
        ViewBag.Title = "Index";
    }
    
    <div id="AllProducts">
        @foreach (var item in Model.Products.ToList())
        {
            @item.Name
            <hr/>
        }
    </div>
        
    <div id="TopRated">
        @foreach (var item in Model.TopRated.ToList())
        {
            @item.Name
            <hr />
        }
    </div>
        
        <div id="Featured">
            @foreach (var item in Model.TopRated.ToList())
            {
                @item.Name
                <hr />
            }
        </div>
