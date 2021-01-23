    public interface IMasterPageItem<out TPage, out TViewModel>
        where TPage : Xamarin.Forms.ContentPage
        where TViewModel : BaseViewModel {
        TPage Page { get; }
        TViewModel ViewModel { get; }
    }
