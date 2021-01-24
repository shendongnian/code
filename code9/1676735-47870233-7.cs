    public class IdeasViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        public List<Ideas> Ideas { get;set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public ICommand GetIdeasCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Ideas= await _apiServices.GetIdeasAsync();
                });
            }
        }
    }
