    //The class is describing your items
    class Item
        {
            public double Angle;
            public double Quantity;
    
            public Item(double angle, double quantity)
            {
                Angle = angle;
                Quantity = quantity;
            }       
        }
    //Collector class
    class Element
    {
        public Element()
        {
            NorthToNortheast.Quantity = 200;
            NorthToNortheast.Angle = 250;
            NortheastToEast.Quantity = 30;
            NortheastToEast.Angle = 300;
        }
        public Item NorthToNortheast { set; get; }
        public Item NortheastToEast { set; get; }
    }
