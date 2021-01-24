    class AllIC : IC {
        private readonly All all;
        public AllIC(All all) {
            if( all == null ) throw new ArgumentNullException(nameof(all));
            this.all = all;
        }
        public void A() => this.all.A();
        public void B() => this.all.B();
    }
    static void Main()
    {
        All all = new All();
        IC ic = new AllIC( all ); // Observe that `ic` is typed as interface `IC` instead of the concrete type `Single`.
        ic.A();
    }
