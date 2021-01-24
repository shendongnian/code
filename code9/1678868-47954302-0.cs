    internal class ChildViewModel
    {
        public ChildViewModel( IEventAggregator eventAggregator )
        {
            CreateItemCommand = new DelegateCommand( () => eventAggregator.GetEvent<ItemCreatedEvent>().Publish( new Item() ) );
        }
    }
    internal class ParentViewModel
    {
        public ParentViewModel( IEventAggregator eventAggregator )
        {
            eventAggregator.GetEvent<ItemCreatedEvent>().Subscribe( x => UpdateData( x.Payload ) );
        }
    }
