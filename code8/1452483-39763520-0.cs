    public class CustomRouter : RoutingLogic
    {
        public override Routee Select(object message, Routee[] routees)
        {
            return routees.OrderBy(WorkerNodeLoadIndex).First();
        }
        private double WorkerNodeLoadIndex(Routee arg)
        {
            return 0.0; // put your real calculation here
        }
    }
