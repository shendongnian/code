    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
        }
        public IEnumerable<MyObject> MyObjects
        {
            get
            {
                yield return new MyObject { Template = "The parameter value is {0} with double value of {1:F2}", Parameter = "asdF1", Double = 1.0 / 3.0 };
                yield return new MyObject { Template = "The parameter value is {0} with double value of {1:F2}", Parameter = "asdF2", Double = 4.5 };
                yield return new MyObject { Template = "The parameter value is {0} with double value of {1:F2}", Parameter = "asdF3", Double = 78 };
                yield return new MyObject { Template = "The parameter value is {0} with double value of {1:F2}", Parameter = "asdF4", Double = Double.PositiveInfinity };
            }
        }
    }
    public class MyObject
    {
        public string Template { get; set; }
        public string Parameter { get; set; }
        public double Double { get; set; }
    }
