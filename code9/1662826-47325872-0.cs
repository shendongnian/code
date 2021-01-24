    public enum LogicType
        {
            actuallogic,
            actuallogic2
        }
    
        public static class LogicExtensions
        {
            public static AbstractLogic LogicClass(this LogicType self)
            {
                switch (self)
                {
                    case LogicType.actuallogic:
                        return new ActualLogic();
                    case LogicType.actuallogic2:
                        return new ActualLogic2();
                    default:
                        return null;
                }
            }
        }
