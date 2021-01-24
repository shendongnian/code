    public abstract class BaseMaster<TChild> where TCHild : BaseChild
    {
        // this probably doesn't have to be 'abstract' anymore
        public abstract ReadOnlyCollection<TChild> Children { get; }
    }
    
    public class FirstRealMaster : BaseMaster<FirstRealChild>
    {
    }
