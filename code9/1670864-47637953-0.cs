    public interface INavigationNode 
    {
    }
    public class NavigationModel
    {
        public List<INavigationNode> NavigationNodes { get; set; }
        public NavigationModel()
        {
    
        }
    
        private class NavigationNode : INavigationNode
        {
    
        }
    }
