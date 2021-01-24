    private static Regex phoneRegex = new Regex(@"^\+\d{1,3}\/\d{8,10}$", RegexOptions.Compiled);
    
    private string phone;
    public string Phone {
        get { return phone; }
        set {
            Match match = phoneRegex.Match(value);
            if (match.Success) {
                phone = value;
            } else {
                throw new ArgumentException("value");
            }
        }
    }
