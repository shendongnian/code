    public interface IAvailableActionProvider 
    {
        ReadOnlyCollection<AwailableAction> GetAvailableActions(User, Request, History/*, etc*/) // Provide parameters that need to define actions.
    }
    public class AvailableActionProvider : IAvailableActionProvider 
    {
        ReadOnlyCollection<AwailableAction> GetAvailableActions(User, Request, History)
        {
            // You logic goes here.
        }
    }
