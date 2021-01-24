    public interface IComponent<T> : IPageViewModel
        where T : AbstractClass
    {
        T DetailsModel {get;}
    }
