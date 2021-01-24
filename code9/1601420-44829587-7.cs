    public interface IPageDisplay
    {
        IPageViewModel GetCurrentPage();
        void ChangeViewModel(IPageViewModel newPage);
    }
