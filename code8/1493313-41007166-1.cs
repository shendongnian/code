    public class Battlefield : Environment {
        public List<ENTITY> Population
        {
          get
          {
            var epop = base.Population;
            return epop.Union(Casualties);
          }
        }
        
        public List<ENTITY> Casualties
        {
          get { return this.casualties; }
        }
    }
