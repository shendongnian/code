    public interface INavigationNode 
    {
      // Add parts of NavigationNode that you want to publish
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
