    public MediaViewModel()
        {
            Foo = new List<Media>();
            FooVideo = new List<Video>();
        }
        public IList<Media> Foo { get; set; }
        public IList<Video> FooVideo { get; set; }
