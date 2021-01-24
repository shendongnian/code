    // Dependencies of Controller
    class Dependencies {
        public IUserDatabase UserDatabase { get; set; }
        public IProductDatabase ProductDatabase { get; set; }
        // more dependencies ...
        public Dependencies(IUserDatabase userDatabase, IProductDatabase productDatabase)
        {
            UserDatabase = userDatabase;
            ProductDatabase = productDatabase;
        }
    }
