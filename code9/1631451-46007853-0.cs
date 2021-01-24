    public class Enums
    {
        public enum Motivators{
         Small_Motivator,
         Medium_Motivator,
         Large_Motivator
        }
        public enum Reactors{
         Small_Reactor,
         Large_Reactor
        }          
        public enum Movers{
         Small_Mover,
         Large_Mover
        }
        public static Enum EnumFactory(string enum_string) {
            if(enum_string.IndexOf("Motivator", StringComparison.OrdinalIgnoreCase) >= 0) {
                return (Motivators) Enum.Parse((typeof(Motivators)), enum_string, true);
            }
            else if(enum_string.IndexOf("Reactor", StringComparison.OrdinalIgnoreCase) >= 0) {
                return (Reactors) Enum.Parse((typeof(Motivators)), enum_string, true);
            }
            else if(enum_string.IndexOf("Mover", StringComparison.OrdinalIgnoreCase) >= 0) {
                return (Movers) Enum.Parse((typeof(Motivators)), enum_string, true);
            }
            return null;
        }
    }
