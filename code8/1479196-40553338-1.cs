    public sealed partial class GamesPage : Page
    {
        public GamesPage()
        {
            this.InitializeComponent();
    
            this.DataContext = new GameControllerViewModel(
                new[]
                {
                    new Team { Name = "Team A" },
                    new Team { Name = "Team B" },
                    new Team { Name = "Team C" },
                    new Team { Name = "Team D" }
                }
            );
        }
    }
