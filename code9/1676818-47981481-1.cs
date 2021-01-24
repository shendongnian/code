    public partial class IdeasSinglePage : ContentPage
    {
      public IdeasSinglePage(List<Models.Ideas> ideas)
      {
        InitializeComponent();
        listViewName.ItemsSource = ideas;
      }
    }
