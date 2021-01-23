    public class GetStyles : IDataSource
    {
        public Item[] ListQuery(Item item)
        {
            bool flag = !string.IsNullOrWhiteSpace(Context.RawUrl) && Context.RawUrl.Contains("hdl");
            if (flag)
            {
                string renderingId = FieldEditorOptions.Parse(new UrlString(Context.RawUrl)).Parameters["rendering"];
    
                if (!string.IsNullOrEmpty(renderingId))
                {
                    ItemUri renderingItemUri = new ItemUri(renderingId);
     
                    var containers = DependencyResolver.Current.GetService<IPresentationRepository>().GetStylesItem(renderingItemUri.ItemID, item);
    
                    if (containers == null)
                        return new Item[0];
    
                    return containers.Children.ToArray<Item>();
                }
            }
    
            var result = new Item[0];
            return result;
        }
    }
