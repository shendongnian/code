    struct EvilStruct
    {
        readonly int _id;
        public EvilStruct(int id) { _id = id; }
        public void EvilMethod() { this = new EvilStruct(_id + 1); }
    }
