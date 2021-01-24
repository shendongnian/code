    abstract class State {
        public sealed Button[] GetHiddenButtons() {
            GetHiddenButtonsInternal();
        }
        public sealed object[] GetObjects() {
            GetObjectsInternal();
        }
        protected abstract Button[] GetHiddenButtonsInternal();
        protected abstract object[] GetObjects();
    }
    abstract class Item {
        State state;
        public abstract void Render();
    }
    class StateA : State {
        public Button[] _hiddenButtons;
        public object[] _objects;
        public StateA()
        {
            //get hidden buttons from somewhere/pass them in/create them.
            _hiddenButtons = new Button[0];
            //get objects from somewhere/pass them in/create them.
            _objects = new object[0];
        }
        protected override Button[] GetHiddenButtons() {
            return _hiddenButtons;
        }
        protected override object[] GetObjects() {
            return _objects;
        }
    }
    class ItemA : Item {
        public ItemA() {
            //read from somewhere else, pass it in, etc.
            state = new StateA();
        }
        public override void Render() {
            //get objects
            var objects = state.GetObjects(); //returns array from StateA
            //get hidden buttons to hide
            var hiddenButtons = state.GetHiddenButtons();
        }
    }
