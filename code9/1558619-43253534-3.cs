    public class ClassLogicProvider : IClassLogic<string, string>
    {
    private readonly Func<IClassLogic<string, string>> innerLogicFactory;
        public ClassLogicProvider(Func<IClassLogic<string, string>> innerLogicFactory)
        {
            this.innerLogicFactory = innerLogicFactory;
        }
        public void Do()
        {
            var classLogic = this.innerLogicFactory();
            classLogic.Do();
        }
    }
