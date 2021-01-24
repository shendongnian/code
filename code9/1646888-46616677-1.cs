    public abstract class BaseClass {
       
        protected virtual bool DefaultStringToBool(string s) {
            <Insert default logic here>;
        }
        protected virtual string DefaultStringToString(string s) {
            <Insert default logic here>;
        }
    }
    public DerivedClass : BaseClass {
        protected override string DefaultStringToString(string s) {
            <Insert override logic here>;
        }
    }
