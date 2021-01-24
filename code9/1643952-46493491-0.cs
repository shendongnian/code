    public class MyDataSet
    {
        public string ID {get;set;}
        public string Description {get;set;}
        public readonly List<MyDataSet> Children = new List<MyDataSet>();
        public bool HasChildren 
        {
            get { return Children.Count > 0 }
        }
        public void GetTree(string id, bool includeChildren)
        {
            MyDataSet mySet = id == null ? this : Children.FirstOrDefault(child => child.ID == id);
            if(mySet == null) return;
            // TODO: handle mySet
            if(includeChildren)
            {
                foreach (MyDataSet child in Children)
                {
                    child.GetTree(null, true);
                }
            }
        }
    }
