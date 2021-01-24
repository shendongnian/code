    class Qwerty {
        public IPen<IModel> A { get; set; }
        public Qwerty() {
            if (true) {
                A = new PenModelA();
            }
            else {
                A = new PenModelB();
            }
        }
    }
