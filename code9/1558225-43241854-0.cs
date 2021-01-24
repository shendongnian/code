    abstract class State {
        public int sharedField;
        public sealed void DoThing() {
            sharedField = 1;
            DoThingInternal();
        }
        protected abstract void DoThingInternal();
    }
    abstract class Item {
        State state;
        public abstract void TestMethod();
    }
    class StateA : State {
        public int customField = 10;
        protected override void DoThingInternal() {
            sharedField = 10;
        }
    }
    class ItemA : Item {
        public ItemA() {
            //read from somewhere else, pass it in, etc.
            state = new StateA();
        }
        public override void TestMethod() {
            state.DoThing();
            Console.WriteLine(state.sharedField); //will print 10
        }
    }
