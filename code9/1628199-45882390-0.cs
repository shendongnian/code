    class Apple {
        public int Weight {get;set;}
    }
    class Orange {
        public int Diameter {get;set;}
    }
    Expression<Func<Apple,bool>> heavy = a => a.Weight > 250;
