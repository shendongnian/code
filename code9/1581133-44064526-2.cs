    public class GBase
    {
        public string Name { get; set; }
    }
    public class GLevel1 : GBase
    {
        
    }
    public class GLevel2 : GBase
    {
    }
    public class CollectionBase<T> : Collection<T> where T : GBase
    { }
    public class CollectionLevel0 : CollectionBase<GBase>
    {
    }
    public class CollectionLevel1 : CollectionLevel0
    {
        
    }
    public class Comparer
    {
        public bool Compare<T>(T old, T newer) where T : CollectionLevel0
        {
            return old[0].Name == newer[0].Name;
        }
    }
