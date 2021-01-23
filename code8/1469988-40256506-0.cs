    using System.Linq;
    public partial class Submenu
    {
        // ...
        public bool Has
        {
            get { return ChildrenMdl != null && ChildrenMdl.Any(); }
        }
        // ...
    }
