        namespace ChartsDisplayer2016.Core.Main.ViewModels
        {
        
            public class MainViewModel: Conductor<Screen>.Collection.OneActive
            {
        
                private readonly IEventAggregator eventAggregator;
                private readonly IWindowManager windowManager;
        
        
                public MainViewModel()
                {
                    //something important;
                }
                public MainViewModel(IEventAggregator eventAggregator,
                                     IWindowManager windowManager)
                {
                    this.eventAggregator = eventAggregator;
                    this.eventAggregator.Subscribe(this);
                    this.windowManager = windowManager;
        
                    //something important
                }
            }
        }
