    public class TLetterAbstract : Type
    {
        private Type _T;
        public TLetterAbstract(object o)
        {
            if (o is LetterAbstract)
            {
                _T = o.GetType();
            }
            throw new ArgumentException("Wrong input type");
        }
        public TLetterAbstract(Type t)
        {
            if (t.IsInstanceOfType(typeof(LetterAbstract)))
            {
                _T = t;
            }
            throw new ArgumentException("Wrong input type");
        }
        public override object[] GetCustomAttributes(bool inherit)
        {
            return _T.GetCustomAttributes(inherit);
        }
        // and some more abstract members of Type implemented by simply forwarding to the instance
    }
