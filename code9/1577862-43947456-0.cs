    public class Root {
        public IList<ShowWrapper> Shows { get; set;}
    }
    public class ShowWrapper { //silly name though ;)
        public IShow Show { get; set;}
    }
