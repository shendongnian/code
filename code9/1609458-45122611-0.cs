    public interface IPresenter<TPresenterElement> where TPresenterElement : IPresenterElement
    {
        BindingList<TPresenterElement> SourceList { get; }
        // ...
    }
    public class PeoplePresenter : IPresenter<People>
    {
        public BindingList<People> SourceList { get; }
        
        // ...
    }
