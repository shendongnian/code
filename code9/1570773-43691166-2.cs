    class ViewModel
    {
        public ViewModel()
        {
            CreateResumeViewModel.NavigateToPage += (sender, type) =>
            {
                NavigateToPage?.Invoke(sender, type);
            };
        }
        public event EventHandler<Type> NavigateToPage; 
        public CreateResumeViewModel CreateResumeViewModel{ get; set; }=new CreateResumeViewModel;
    }
