    public interface IMyPresenter 
    {
    }
    public interface IMyPresenter<TView> : IMyPresenter
        where TView : IMyView
    {
    }
    public interface IMyView
    {
    }
    public interface IMyView<TPresenter> : IMyView
        where TPresenter : IMyPresenter
    {
    }
    public class MyView : IMyView<MyPresenter>
    {
    }    
    public class MyPresenter : IMyPresenter<MyView>
    {
    }
