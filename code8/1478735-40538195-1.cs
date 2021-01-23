    public class ClassUnderTest
    {
        private readonly IAsyncDelayer asyncDelayer;
        public ClassUnderTest(IAsyncDelayer asyncDelayer)
        {
            this.asyncDelayer = asyncDelayer;
        }
        public async Task<int> MethodUnderTest()
        {
            await asyncDelayer.Delay(TimeSpan.FromSeconds(2));
            return 5;
        }
    }
