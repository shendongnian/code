    public class RibbonTabItemRegionAdapter : RegionAdapterBase<RibbonTabItem>
    {
        public RibbonTabItemRegionAdapter( IRegionBehaviorFactory regionBehaviorFactory ) : base( regionBehaviorFactory )
        {
        }
        protected override void Adapt( IRegion region, RibbonTabItem regionTarget )
        {
            region.ActiveViews.CollectionChanged += ( s, e ) =>
                                                    {
                                                        switch (e.Action)
                                                        {
                                                            case NotifyCollectionChangedAction.Add:
                                                                foreach (var newItem in e.NewItems)
                                                                    regionTarget.Groups.Add( (RibbonGroupBox)newItem );
                                                                break;
                                                            case NotifyCollectionChangedAction.Remove:
                                                                foreach (var oldItem in e.OldItems)
                                                                    regionTarget.Groups.Remove( (RibbonGroupBox)oldItem );
                                                                break;
                                                        }
                                                    };
        }
        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
