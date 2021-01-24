    public class ValidBasedOnFoo
    {
        public int MethodNum { get; set; }
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            var foo = controllerContext.HttpContext.Request["foo"] as string;
            if (MethodNum == 1)
                return YourDecisionLogicForFirstAction(foo);
            else if (MethodNum == 2)
                return YourDecisionLogicForSecondAction(foo);
            else throw new InvalidOperationException("Unknown method number.");
        }
    }
