    public class CustomJpg : IComparable<CustomJpg>
    {
        public CustomJpg(string path)
        {
            this.Path = path;
        }
    
        public string Path { get; private set; }
    
        private double number = -1;
        // You can even make this public if you want.
        private double Number
        {
            get
            {
                // Let's cache the number for subsequent calls
                if (this.number == -1)
                {
                    int myStart = this.Path.IndexOf("(") + 1;
                    int myEnd = this.Path.IndexOf(")");
                    string myNumber = this.Path.Substring(myStart, myEnd - myStart);
                    double myVal;
                    if (double.TryParse(myNumber, out myVal))
                    {
                        this.number = myVal;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("{0} has no parenthesis or a number between parenthesis.", this.Path));
                    }
                }
    
                return this.number;
            }
        }
    
        public int CompareTo(CustomJpg other)
        {
            if (other == null)
            {
                return 1;
            }
    
            return this.Number.CompareTo(other.Number);
        }
    }
