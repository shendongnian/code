    @model ActionFilterTest.ViewModels.ItemViewModel<ActionFilterTest.Models.DerivedItem2>
    
    <label for="type">Model.Item.Type:</label>
    <div name="type">@Model.Item.Type</div>
    
    @{ Model.Item.Alter(); }
    
    <label for="note">Model.Item.Note:</label>"
    <div name="note">@Model.Item.Note</div>
