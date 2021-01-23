    public abstract class SaveableObjectBase : ISaveableObject {
        protected object[] parameters = new object[0];
        private SaveableObjectBase() { }
        protected SaveableObjectBase(object[] objects) {
            this.parameters = objects;
        }
        public abstract string ToSaveableObject();
    }
