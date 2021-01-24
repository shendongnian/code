    public class SUT
    {
        private readonly IMyInterface dependency;
        public SUT(IMyInterface dependency)
        {
            this.dependency = dependency;
        }
        // ...
    }
