    // Wrapper class protecting a shared double value implementing mutual exclusion:
    public class SharedDoubleValue
    {
        private double value;
    
        public SharedDoubleValue(double val)
        {
            this.Value = val;
        }
    
        public double Value 
        {
            get
            {
                lock (this)
                {
                    return value;
                }
            }
    	   
            set
            {
                lock (this)
                {
                    this.value = value;
                }
            }
        }
    }
    
    public double ComputeSum(List<double> numbers, SharedDoubleValue thresholdValue)
    {
        SharedDoubleValue sum = new SharedDoubleValue(0);
       
        Parallel.ForEach (numbers, (number) => 
        {
            if (number >= thresholdValue.Value)
            {
                sum.Value += number;
            }	
        });
        return sum.Value;
    }
