    namespace Practice3
    {
        public partial class MainPage : ContentPage
        {
            public ObservableCollection<Film> Films { get; set; }
    
            public MainPage()
            {
                InitializeComponent();
    
                Films = new ObservableCollection<Film>{
                    new Film{
                        Title = "X-Men (2000)",
                        Resume = "Two mutants come to a private academy for their kind whose resident superhero team must oppose a terrorist organization with similar powers."
                    },
                    new Film{
                        Title = "X-Men 2 (2003)",
                        Resume = "The X-Men band together to find a mutant assassin who has made an attempt on the President's life, while the Mutant Academy is attacked by military forces."
                    },
                    new Film{
                        Title = "X-Men: The last stand (2006)",
                        Resume = "When a cure is found to treat mutations, lines are drawn amongst the X-Men, led by Professor Charles Xavier, and the Brotherhood, a band of powerful mutants organized under Xavier's former ally, Magneto."
                    }
                };
                FilmList.ItemsSource = Films;
            }
        }
    }
