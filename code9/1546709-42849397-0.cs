    codeExample:
            ClockGen clockGen = new ClockGen();
            clockGen.Mode = ClockMode.FullSpeed;
            clockGen.Clock += ClockGen_Clock;
            clockGen.Start();
        private void ClockGen_Clock(object sender, EventArgs e)
        {
            // Do you data set 
        }
            
