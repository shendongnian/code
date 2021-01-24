    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
        }
        public IEnumerable<MyObject> MyObjects
        {
            get
            {
                yield return new MyObject { Template = "The parameter value is {0}", Parameter = "asdF1" };
                yield return new MyObject { Template = "The parameter value is {0}", Parameter = "asdF2" };
                yield return new MyObject { Template = "The parameter value is {0}", Parameter = "asdF3" };
                yield return new MyObject { Template = "The parameter value is {0}", Parameter = "asdF4" };
            }
        }
    }
    public class MyObject
    {
        public string Template { get; set; }
        public string Parameter { get; set; }
    }
