    public interface IHasColor 
    {
      string color { get; set; }
    }
    
    public class car : IHasColor
    {
        public color { get; set; }
        ...
    }
    
    foreach (IHasColor thing in new IHasColor[] { beemer, panda })
    {
        thing.color = "red";
    }
