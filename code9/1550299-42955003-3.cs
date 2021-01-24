    public sealed partial class CreatureDossier : Page
    {
        public CreatureDossier()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            uc.Cat = (Species)e.Parameter;
        }
    }
----------
    <TextBlock x:Name="CatName" Text="{Binding Cat.name, Mode=OneWay}" />
