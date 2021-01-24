    public interface ISampleInterface
    {
        void Run();
    }
    
    public class SampleClass : ISampleInterface
    {
        public Action Run { get; set; }
        void ISampleInterface.Run()
        {
            this.Run();
        }
    }
    
    public void ActionRunner(ISampleInterface param)
    {
        param.Run();
    }
    public void someFumction()
    {
        ActionRunner(new SampleClass
        {
            Run = () =>
            {
                // Code goes here 
            }
        });
    }
