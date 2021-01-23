    public class Temperatures
    {
        private double sum;
        private int daysInWeek;
        public double[] WeeksTemperatures { get; set; }
        public double ThreshTemp { get; set; }
        public double Average { get; set; }
        public double AverageExcludingLowest { get; set; }
        public double Highest { get; set; }
        public double Lowest { get; set; }
        public int NumOfThreshs { get; set; }
        public Temperatures(double[] wTemperatures, double threshT)
        {
            this.WeeksTemperatures = wTemperatures;
            this.ThreshTemp = threshT;
            sum = 0.0;
            daysInWeek = 7;
        }
        public void GetWeekStatistics()
        {
            GetSum();
            DetermineLowest();
            DetermineHighest();
            DetermineAverage();
            DetermineAverageExcludingLowest();
            DetermineNumberOfThreshs();
        }
        private void GetSum()
        {
            for (int x = 0; x < daysInWeek; x++) //Traverse through the week's temperatures
            {
                this.sum = this.sum + this.WeeksTemperatures[x];
            }
        }
        public void DetermineLowest()
        {
            this.Lowest = this.WeeksTemperatures[0];
            for (int x = 0; x < daysInWeek; x++) //Traverse through the week's temperatures
            {
                if (this.WeeksTemperatures[x] < this.Lowest)   //find the lowest temperature of the week
                {
                    this.Lowest = this.WeeksTemperatures[x];   //and set it to lowest
                }
            }
        }
        public void DetermineHighest()
        {
            this.Highest = this.WeeksTemperatures[0];
            for (int x = 0; x < daysInWeek; x++) //Traverse through the week's temperatures
            {
                if (this.WeeksTemperatures[x] > this.Highest)  //find the highest temperature of the week
                {
                    this.Highest = this.WeeksTemperatures[x];  //and set it to highest
                }
            }
        }
        private void DetermineAverage()
        {
            this.Average = this.sum / daysInWeek;
        }
        public void DetermineAverageExcludingLowest()
        {
            this.AverageExcludingLowest = ((this.sum - this.Lowest) / daysInWeek);   // calculate average excluding lowest temperature
        }
        public void DetermineNumberOfThreshs()
        {
            for (int x = 0; x < daysInWeek; x++) //Traverse through the week's temperatures
            {
                if (this.WeeksTemperatures[x] < this.ThreshTemp)   //find the lowest temperature of the week
                {
                    this.NumOfThreshs++;
                }
            }
        }
        public override string ToString()
        {
            return "=====================\nWeekly Statistics\n" + "---------------------\n" + "Average Temperature: " + this.Average + "\nHighest Temperature: "
            + this.Highest + "\nLowest Temperature: " + this.Lowest + "\nAvg. Excl. Lowest: " + this.AverageExcludingLowest + "\n# of Cold Days: " + this.NumOfThreshs + "\n====================="; //Formats and the invoice to be printed
        }
    }
