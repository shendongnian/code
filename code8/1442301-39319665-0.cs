    class Operations
    {
        public static Operation Plus = new Operation { Op = "+" };
        public static Operation Minus = new Operation { Op = "-" };
        public static Operation Times = new Operation { Op = "*" };
        public static Operation Divide = new Operation { Op = "/" };
    }
    class Operation
    {
        public string Op;
    }
