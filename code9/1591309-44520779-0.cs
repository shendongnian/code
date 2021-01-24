    public interface IThing {}
    public interface IWrapping<IThing> {}
    public class Paper<TThing> : IWrapping<TThing> where TThing : IThing {}
    public class Cookie : IThing {}
    public class Carmel : IThing{}
    public class Chocolate : IThing{}
