    public class Product:ObservableObject,  IKeyObject
        {
            [SQLite.PrimaryKey]
            public string Id { get; set; }     //this is cause i am using sqlite
            //other properties
            private bool _isFavorite;
            public bool IsFavorite
            {
              get => _ isFavorite;
              set { _ isFavorite = value; OnPropertyChanged(); }
            } 
                
        }
