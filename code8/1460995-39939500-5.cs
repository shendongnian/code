    @model ActionFilterTest.ViewModels.ItemViewModel<ActionFilterTest.Models.BaseItem>
    
    <h4>BaseItem</h4>
    <hr />
    <label for="item">Model.Item.Type: </label>
    <div name="item">@Model.Item.Type</div>
    @{ Model.Item.Alter(); }
    <label for="note">Model.Item.Note:</label>"
    <div name="note">@Model.Item.Note</div>
