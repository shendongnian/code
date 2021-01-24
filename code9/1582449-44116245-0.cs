    public class DataAccessRegistry : Registry {
        public DataAccessRegistry() {
            For<IWidget>().Singleton().Use<DefaultWidget>();
        }
    }
