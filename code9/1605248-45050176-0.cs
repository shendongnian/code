        ServoController servo = new ServoController(5);
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await servo.Connect();
        }
        private void MoveServoToCentre(double MovementTime, double CalculatedFrequency)
        {
            servo.Frequency = Convert.ToInt32(CalculatedFrequency);
            servo.SetPosition(90).AllowTimeToMove(Convert.ToInt32(MovementTime)).Go();
        }
