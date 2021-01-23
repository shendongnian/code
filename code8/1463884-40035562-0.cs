    public interface IPizza
    {
        //just example method
        public int Price();
        public string Name{ get; set; };
    }
    
    public class Peperoni: IPizza
    {
        private string _name = "Peperoni Pizza";
        public int Price()
        {
             return 10;
        }
        public string Name
        {
            get { return _name;}
            set { _name=value;}
        }
    }
    
    public class Cheese: IPizza
    {
        private string _name = "Cheese Pizza";
        public int Price()
        {
             return 8;
        }
        public string Name
        {
            get { return _name;}
            set { _name=value;}
        }
    }
    // and so on
