    public class Program
    {
        public struct Location
        {
            // Assumes 2D game location
            public int X;
            public int Y;
        }
        
        public struct Character
        {
            public int GameCharId;
        }
        
        public class BaseObjective
        {
            public string Title;
            public string Description;
        }
        
        public class TalkObjective : BaseObjective
        {
            public Character TargetCharacter; 
        }
        
        public class LocationObjective : BaseObjective
        {
            public Location TargetLocation;
        }
        
        public static void Main(string[] args)
        {
            List<BaseObjective> currentObjectives = new List<BaseObjective>();
            TalkObjective obj1 = new TalkObjective(){ Title = "Talk to Bob", Description = "Bob has some useful information for you", TargetCharacter = new Character(){GameCharId = 87}};
            LocationObjective obj2 = new LocationObjective(){ Title = "Find the thing", Description = "Bob informed you of a thing, go and find it", TargetLocation = new Location(){ X = 33, Y=172}};
            
            
            currentObjectives.Add(obj1);
            currentObjectives.Add(obj2);
        }
    }
