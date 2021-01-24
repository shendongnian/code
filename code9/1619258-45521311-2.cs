    public class IdeasViewModel : ViewModelBase {
        public List<IdeaResource> IdeasList;
        public IdeasViewModel() {
            Initialized += OnInitialized;
            Initialized(this, EventArgs.Empty);
        }
    
        private event EventHandler Initialized = delegate { };
    
        private async void OnInitialized(object sender, EventArgs e) {
            //unsubscribing from the event
            Initialized += OnInitialized;
            //call async 
            var client = new HypermediaClient();
            IdeasList = await client.GetIdeasAsync();   
        }
    }
