    class B : IAOne {
        private IAOne _a;
        public B(IAOne a) { _a = a; }
        void method1() { _a.method1(); }
        void method2() { _a.method2(); }
        void method3() { _a.method3(); }
    }
