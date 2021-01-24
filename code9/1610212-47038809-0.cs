    public class HamburgerMenuItemCollectionRegionAdapter : RegionAdapterBase<HamburgerMenuItemCollection>
    {
        public HamburgerMenuItemCollectionRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }
        protected override void Adapt(IRegion region, HamburgerMenuItemCollection regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (HamburgerMenuGlyphItem element in e.NewItems)
                    {
                        regionTarget.Add(element);
                    }
                }
            };
        }
        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
