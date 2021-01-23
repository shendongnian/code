    public interface ISearchDefinition
    {
        IEnumerable<string> SearchTerms { get; }
    }
    public class ConcreteSearchDefinition : ISearchDefinition
    {
        public IEnumerable<string> SearchTerms { get; }
        public ConcreteSearchDefinition(List<string> searchTerms)
        {
            SearchTerms = searchTerms;
        }
    }
    public partial class Search : Form
    {
        public Search(ISearchDefinition definition)
        {
            // Now you can get to definition.SearchTerms and whatever else you define
        }
    }
    List<string> list = new List<string> { "help", "save", "me" };
    Search search = new Search(new ConcreteSearchDefinition(list));
