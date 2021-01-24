    public partial class csvRow
    {
        private List<csvRow> children = new List<csvRow>();
        public List<csvRow> Children
        {
            get
            {
                // This is a quite neet way of sorting, isn't it?
                //Btw this is all the sorting we are doing, recursion for win!
                return children.OrderBy(row => row.MenuName).ToList();
            }
        }
        public void addChildrenFrom(List<csvRow> unsortedRows)
        {
            // Add's only rows where this is the parent.
            this.children.AddRange(unsortedRows.Where(
                //Avoid running into null errors
                row => row.ParentId.HasValue &&
                //Find actualy children
                row.ParentId == this.Id &&
                //Avoid adding a child twice. This shouldn't be a problem with your data,
                //but why not be careful?
                !this.children.Any(child => child.Id == row.Id)));  
            
            //And this is where the magic happens. We are doing this recursively.
            foreach (csvRow child in this.children)
            {
                child.addChildrenFrom(unsortedRows);
            }
        }
        //Depending on your use case this function should be replaced with something
        //that actually makes sense, it's an example on
        //how to read from a recursiv structure.
        public List<string> FamilyTree
        {
            get
            {
                List<string> myFamily = new List<string>();
                myFamily.Add(this.MenuName);
                //Merges the Trees with itself as root.
                foreach (csvRow child in this.children)
                {
                    foreach (string familyMember in child.FamilyTree)
                    {
                        //Adds a tab for all children, grandchildren etc.
                        myFamily.Add("\t" + familyMember);
                    }
                }
                return myFamily;
            }
        }
    }
