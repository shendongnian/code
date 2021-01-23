    class __horribleTypeName {
        public Something amazon;
        public SomethingElse visa;
        public AnotherSomething dhl;
        public void __horribleMethodName() {
            amazon.Buy("Lego", visa, dhl);
        }
    }
    ...
    var __horribleLocalName = new __horribleTypeName();
    var __horribleLocalName.amazon = ... // etc
    Thread amazonBuy1 = new Thread(__horribleLocalName.__horribleMethodName);
