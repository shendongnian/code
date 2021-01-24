    public partial class Window2 : Window
    {
        public ObservableCollection<Player> PlayerCollection { get; set; } = new ObservableCollection<Player>();
        public static ObservableCollection<Race> RaceCollection { get; set; } = new ObservableCollection<Race>();
        static Window2()
        {
            var raceList = Enum.GetValues(typeof(Race)).Cast<Race>();
            foreach (var race in raceList)
            {
                RaceCollection.Add(race);
            }
        }
        public Window2()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += (s, e) =>
            {
                PlayerCollection.Add(new Player() { Name = "Samuel", Race = Race.Human });
                PlayerCollection.Add(new Player() { Name = "Scoof", Race = Race.Orc });
                PlayerCollection.Add(new Player() { Name = "Sel", Race = Race.Elf });
            };
        }
    }
