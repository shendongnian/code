    public partial class IdeasSinglePage : ContentPage
    {
     public IdeasSinglePage(List<Models.Ideas> ideas)
     {
       InitializeComponent();
       this.listViewId.itemsSource = ideas;
     }
    }
