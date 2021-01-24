    public class MyWorker
    {
        private List<IMyInterface> _myAccumulatorClasses = new List<IMyInterface> { new MyClassA(), new MyClassB() }
    
        public void CallClasses()
        {
            foreach(var accumulator in myAccumulatorClasses.OrderBy(x=>x.Order)))
            {
                var value = accumulator.DoWork();
    
                if(value > 0)
                    break;  // Don't call next accumulator if we get a value greater than zero back.
            }
    
        }
    }
