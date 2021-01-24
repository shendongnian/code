    public class Kid {
        public Kid(int initialAge = 0) {
            Age = initialAge;
        }
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
