    @{
        var Artikelen = Model.Content
            .Children
            .Where(c => c.DocumentTypeAlias == "newsDetail");
    
        var distinctTags = Artikelen
            .SelectMany(a => a.GetPropertyValue<IEnumerable<IPublishedContent>>("themeTags"))
            .GroupBy(node => node.Name)
            .Select(group => group.First());
    }
    
    @foreach (var tag in distinctTags)
    {
        <center>
            <a class="ajaxFilter" data-catId="@tag.Id">@tag.Name</a>
        </center>
    } 
