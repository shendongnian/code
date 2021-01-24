     public class ItemControlViewModel : NotificationBase
        {
            public ObservableCollection<CoolStuff> MyCoolStuff { get; set; }
    
            public ItemControlViewModel()
            {
                MyCoolStuff = new ObservableCollection<CoolStuff>() {
                new CoolStuff() { Name = "Cool Book", Description = "A copy of a really cool book", Date = "1979" },
                new CoolStuff() { Name = "Cool Movie", Description = "A copy of a really cool movie", Date = "1980" },
                new CoolStuff() { Name = "Cool Album", Description = "A copy of a really cool album", Date = "1991" }
                };
            }
    }
