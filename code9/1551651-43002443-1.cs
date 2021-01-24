    public class PayCheck {
        private double _salary = -1;
    
        public double Salary {
            get => _salary;
            set {
                _salary = value;
                if (value > 2000)
                    Tax = 20;
                else if (value > 1500)
                    Tax = 10;
                else
                    Tax = 5;
            }
        }
        public double Tax { get; private set; }
    }
