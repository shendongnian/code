    class CatWrapper
    {
        private int position { get; set; }
        public CatWrapper(Cat cat) { ... }
        public CatWrapper(CoolCat cat) { ... }
        public CatWrapper(ReallyCoolCat cat) { ... }
        public DistanceFrom(CatWrapper other) { ... }
    }
