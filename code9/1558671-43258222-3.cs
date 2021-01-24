    public class LocalAccountViewModel : INotifyPropertyChanged
    {
           public INavigation Navigation { get; set;}
            public LocalAccountViewModel(INavigation navigation)
            {
                this.Navigation = navigation;
                this.ContinueBtnClicked = new Command(async () => await GotoPage2());
            }
            public async Task GotoPage2()
            {
                 /////
                 await Navigation.PushAsync(new Page2());
            }
            ...
            
