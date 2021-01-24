    /// <summary>
    /// Turns a flat list of titles into a list where each element contains a list of it children, themselves containing a list of childre, ...
    /// </summary>
    /// <param name="titles">A flat list of titles</param>
    /// <returns>A "cascading" list of titles</returns>
    internal List<Title> GetTitleHierarchy(List<Title> titles)
    {
        return PutInParent(titles);
    }
    private List<Title> PutInParent(List<Title> titles)
    {
        var output = new List<Title>();
    
        for (int i = 0; i < titles.Count; i++)
        {
            // Copy because if passed by reference we'll get loop-referencing
            var title = titles.Get(i).Copy();
    
            var childrenCount = CountChildren(titles, i);
            if (childrenCount > 0)
            {
                var subItems = titles.GetRange(i + 1, childrenCount);
                title.Children = PutInParent(subItems);
            }
    
            output.Add(title);
            i += childrenCount;
        }
    
        return output;
    }
    
    /// <summary>
    /// Returns the number of titles after the current index that should be children of the current element
    /// </summary>
    /// <param name="titles">the flat list of elements</param>
    /// <param name="startIndex">the current position in the list</param>
    /// <returns></returns>
    internal int CountChildren(List<Title> titles, int startIndex)
    {
        var clidrenCount = 0;
        
        foreach (var title in titles.Skip(startIndex + 1))
        {
            if (title.IsLevelLowerThan(titles.Get(startIndex).Level))
                break;
    
            clidrenCount++;
        }
    
        return clidrenCount;
    }
    
    internal class Title
    {
        public TitleLevel Level { get; set; }
        public string Value { get; set; }
        public IEnumerable<Title> Children { get; set; }
    
        #region Overrides of Object
    
        public override string ToString()
        {
            return $"{Level} - {Value}";
        }
    
        #endregion
    
        public Title Copy()
        {
            return new Title
            {
                Level = Level,
                Value = Value,
                Children = Children.Select(c => c.Copy())
            };
        }
    
        public bool IsLevelLowerThan(TitleLevel targetLevel)
        {
            return (int) Level <= (int) targetLevel;
        }
    }
    
    internal enum TitleLevel
    {
        H1 = 1,
        H2 = 2,
        H3 = 3,
        H4 = 4,
        H5 = 5,
        H6 = 6,
        DummyValue = 0
    }
