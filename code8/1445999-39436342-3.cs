    public abstract class SaveableObject {
        protected object[] parameters = new object[0];
        protected SaveableObjectBase(object[] objects) {
            this.parameters = objects;
        }
        public abstract string ToSaveableObject();
    }
