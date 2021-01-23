    public class Model
    {   
    }
    public interface IView<M>
    {
        M Model { get; }
    }
    public class MyView : IView<Model>
    {
        public MyView(Model model)
        {
            Model = model;
        }
        public Model Model
        {
            get;
        }
    }
    public interface IController<V, M>
    {
        M Model { get; }
        V View { get; }
    }
    public class MyController : IController<MyView, Model>
    {
        public MyController(MyView view, Model model)
        {
            View = view;
            Model = model;
        }
        public Model Model
        {
            get;
        }
        public MyView View
        {
            get;
        }
    }
