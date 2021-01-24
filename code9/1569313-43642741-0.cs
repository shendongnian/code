        //ctor
        public MyViewModel()
        {
            using(var db = new MyDbContext()} ... //
        }
    calling BD, or FileSystem in constuctor is bad practice anyway
