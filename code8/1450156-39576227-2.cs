    class Car
    {
        public int Speed { get; set; }
        public Car(int initialSpeed)
        {
            Speed = initialSpeed;
        }    
    
        public void Accelerate() => Speed += 10;   
        public void Brake() => Speed -= 10;
    }
