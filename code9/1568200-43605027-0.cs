    public class YourClass : INotifyPropertyChanged 
    {
        private int _num;
    
        public int Num
        {
            get => _num;
            set
            {
                if (Equals(value, _num)) return;
                _num = value;
    
            
                if (value >= 0 && value <= 4)
                {
                    Col = Brushes.Red;
                }
                else if (value >= 5 && value <= 10)
                {
                    Col = Brushes.Green;
                }
                else if (value >= 11 && value <= 14)
                {
                    Col = Brushes.Blue;
                }
                else if (value >= 15 && value <= 18)
                {
                    Col = Brushes.Yellow;
                }
                else if (value >= 18 && value <= 23)
                {
                    Col = Brushes.Orange;
                }
    
                OnPropertyChanged();
            }
        }
    
        private Brush _col;
        public Brush Col
        { 
            get => _col;
            set {
                _col = value;
                OnPropertyChanged();
            }
        }
    }
