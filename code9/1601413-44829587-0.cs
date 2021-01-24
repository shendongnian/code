    public interface IPageDisplay
    {
        IPageViewModel GetCurrentPage();
        void ChangeViewModel(IPageViewModel newPage);
    }
    public class ApplicationViewModel: IPageDisplay
    {
        // implement like you are doing
