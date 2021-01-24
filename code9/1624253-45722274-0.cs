        // Get tags of current item I'm on
        var tags = Umbraco.TagQuery.GetTagsForEntity(Node.getCurrentNodeId()).DistinctBy(t => t.Text).OrderBy(t => t.Text);
        
        // Create blank list to add to in foreach loop
        var combinedList = new List<IPublishedContent>();
        
        // Get related content by tag for each tag, add to the list
        foreach (var tag in tags)
        {
            var tagString = tag.Text;
            var taggedContent = Umbraco.TagQuery.GetContentByTag(tagString);
            combinedList.AddRange(taggedContent);
        }
        
        // Filter list to only idea items, order by latest, then remove duplicates
        var taggedItems = combinedList.Where(c => c.IsDocumentType("NewsPage", true) && c.IsVisible() && c.Id != CurrentPage.Id).OrderBy("Id descending").DistinctBy(x => x.Id).Take(8);
        
        if (taggedItems.Any())
        {
            foreach (var relatedItem in taggedItems)
            {
            <a href="@relatedItem.Url">
            @{
                var pageTitle = relatedItem.GetPropertyValue("pageTitle").ToString();
            }
            <h6>@Umbraco.Truncate(pageTitle, 80, true)</h6>
        </a>
        }
