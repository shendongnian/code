    public class Example
    {
        public string this[string s] // square bracket operator with string argument
        {
            get 
            {
                return somethingToReturnString;
            }
            set
            {
                somethingToSetString = value;
            }
        }
        public string this[int i] // square bracket operator with int argument
        {
            get 
            {
                return somethingToReturnInt;
            }
            set
            {
                somethingToSetInt = value;
            }
        }
    }
