    public class Car
    {
        private int _speed;
        public int Speed { get { return _speed; } }
        public void GoFaster()
        {
            if (_speed < 200) _speed++;
        }
        public void SlowDown()
        {
            if (_speed > 0) _speed--;
        }
    }
