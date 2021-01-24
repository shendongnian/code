    Using System;
    Using System.Collections.Generic
    public class Coffee 
    {
        private List<int> info;
        public Coffee(List<int> info)
        {
           this.info = new List<int>(info);
        }
        public List <int> Restore()
        {
           return new List<int>(this.info);
        }
    }
