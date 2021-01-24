    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public class ConversionViewModel : INotifyPropertyChanged
    {
        private double depth;
        private double speed;
        public double Speed {
            get { return this.speed; }
            set {
                this.speed = value;
                this.OnPropertyChanged();
                this.Depth = this.CalculateDepth();
            }
        }
        public double Depth {
            get { return this.depth; }
            set {
                this.depth = value;
                this.OnPropertyChanged();
                this.Speed = this.CalculateSpeed();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private double CalculateSpeed()
        {
            // do your calculation
            return 0;
        }
        private double CalculateDepth()
        {
            // do your calculation
            return 0;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
