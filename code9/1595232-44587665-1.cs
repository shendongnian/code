    public class Csvs<T>
    {
        private List<T> parsedDockets; // assume you have something like this:
        public IDockets Dockets{ get { return new Dockets(parsedDockets); } }
    }
