    using System;
    using System.Collections.Generic
    public class Coffee 
    {
        private List<int> info;
        public Coffee(List<int> info)
        {
          this.info = info.ToList();
        }
        public List <int> Restore()
        {
          return this.info.ToList();
        }
    }
