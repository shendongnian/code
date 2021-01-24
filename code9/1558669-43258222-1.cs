    public class LocalAccountViewModel : INotifyPropertyChanged
    {
           public ICurrentNavigation Navigation { get; set;}
            public LocalAccountViewModel(ICurrentNavigation navigation)
            {
                this.Navigation = navigation;
                this.ContinueBtnClicked = new Command(async () => await GotoPage2());
            }
            public async Task GotoPage2()
            {
                 /////
                 await Navigation.GetCurrent().PushAsync(new Page2());
                 // or await Navigation.GetCurrent().PushModalAsync(new Page2());
            }
            ...
            
