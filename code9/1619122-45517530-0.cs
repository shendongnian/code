    //Logic.cs
    public class Logic : ILogic {
        private readonly IDocumentService injectedDocServiceActualTarget;
        public Logic(IDocumentService injected2) {
            this.injectedDocServiceActualTarget=injected2;
        }
        public void injest(string id) {
            injectedDocServiceActualTarget.doWork(id);
        }
    }
