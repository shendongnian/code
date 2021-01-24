    public class ViewModel 
    {
        static ViewModel viewModel;
        public static Instance { get {return viewModel ?? (viewModel == new ViewModel());}}
        public bool IsAdmin {get;set;}
    }
