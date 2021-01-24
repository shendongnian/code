    public class Kid {
        public virtual float Age { get; private set; }
        public bool IsAdult { get; private set; }
        private float _ageIncreasePerHour = 1;
        public void OnHourPass() {
            Age += _ageIncreasePerHour;
            if (Age >= 3) {
                IsAdult = true;
            }
        }
    }
