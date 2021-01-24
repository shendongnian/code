        public class Order
        {
            public int OrderID { get; set; }
            [OnlyOneValue(nameof(Field2))]
            public string Field1 { get; set; }
            [OnlyOneValue(nameof(Field1))]
            public string Field2 { get; set; }
            //other properties 
        }
