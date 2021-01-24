    private class DisplayClass
    { 
        public readonly Game kkk;
        public DisplayyClass(Game kkk) { this.kkk = kkk; }
        public T handler(Pirate p) { return Manager.method(kkk, p); }
    }
    public Prediction(Game kkk,bool checkit, params State[] checkStates)
        : base(game, new DisplayClass(kkk).handler)
    {
        this.checkit= checkit;
        this.checkStates = checkStates;
    }
