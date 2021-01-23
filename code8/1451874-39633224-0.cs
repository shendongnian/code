    public class OrderTemp
    {
        /*  other members of the class */
        public OrderTemp Clone()
        {
            return new OrderTemp
            {
                property1 = this.property1;
                property2 = this.property2;
                /* and so on */
            };
        }
    }
