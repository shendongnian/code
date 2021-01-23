    //The class is describing your items
    class Item
        {
            public double Angle;
            public double Auantity;
    
            public Item(double angle, double auantity)
            {
                Angle = angle;
                Auantity = auantity;
            }       
        }
    //Collector class
    class Element
    {
        public Element()
        {
            NorthToNortheast.Auantity = 200;
            NorthToNortheast.Angle = 250;
            NortheastToEast.Auantity = 30;
            NortheastToEast.Angle = 300;
        }
        public Item NorthToNortheast { set; get; }
        public Item NortheastToEast { set; get; }
    }
