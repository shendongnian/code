    public interface IExecutionClass {
        void TakeAction();
    }
    public class ExecutionClass : IExecutionClass {
        private readonly IConditionMaker _conditionMaker;
        public ExecutionClass(IConditionMaker conditionMaker) {
            _conditionMaker = conditionMaker;
        }
        public void TakeAction() {
            if (_conditionMaker.IsConditionTrue()) {
                // do your action
            }
        }
    }
