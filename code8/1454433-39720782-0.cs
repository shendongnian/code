    public abstract class ViewObject
    {
        public virtual string Id
        {
            get { return this.GetType().Name; }
            set { throw new NotSupportedException(); }
        }
    }
    public class Object : ViewObject
    {
        private string id = string.Empty;
        public override string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
