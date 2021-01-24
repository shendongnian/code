    public abstract class Smell
    {
        public abstract string GetAdjective();
        public string GetDescription()
        {
            return "I smell " + GetAdjective();
        }
    }
    public class NastySmell : Smell
    {
        public override string GetAdjective() { return "really nasty"; }
    }
