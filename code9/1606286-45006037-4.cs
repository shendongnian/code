    public class ViewModel 
    {
        ViewModel viewModel;
        public static Instance { return viewModel ?? (viewModel == new ViewModel());}
        public bool IsAdmin {get;set;}
    }
