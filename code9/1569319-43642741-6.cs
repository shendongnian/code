        //ctor
        public MyViewModel()
        {
            using(var db = new MyDbContext()} ... //
        }
    calling DB, or FileSystem in constuctor is bad practice anyway
