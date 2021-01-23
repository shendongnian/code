    public class ConditionMaker : IConditionMaker {
        public bool IsConditionTrue() {
            bool isTrue = true;
            bool isAlsoTrue = true;
            bool isTrueToo = true;
    
            return (isTrue && isAlsoTrue && isTrueToo);
        }
    }
