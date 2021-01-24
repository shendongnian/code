    public interface IApp { }
    public class App : IApp
    {
        public App(IOne iOneInstance, ITwo iTwoInstance) { /* Irrelevant */}
    }
    public interface IOne { }
    public class OneA : IOne { }
    public class OneB : IOne { }
    public interface ITwo { }
    public class TwoA : ITwo { }
    public class TwoB : ITwo { }
