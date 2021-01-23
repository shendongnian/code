    public abstract class MyBasePresenter 
    {
    }
    public abstract class MyBasePresenter<TView> : MyBasePresenter
        where TView : MyBaseView
    {
    }
    public abstract class MyBaseView
    {
    }
    public abstract class MyBaseView<TPresenter> : MyBaseView
        where TPresenter : MyBasePresenter
    {
    }
    public class MyView : MyBaseView<MyPresenter>
    {
    }
    public class MyPresenter : MyBasePresenter<MyView>
    {
    }
