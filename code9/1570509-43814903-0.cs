    public class Interfaces
    {
        internal static void EnableInterfaces(UserContext userContext,  ClientLogicalForm Page)
        {
            Page.Activate();
            Page.Control("Editable").Activate();
            Page.Control("Editable").SaveValue(true);
            Page.Control("Show").Activate();
            Page.Control("Show").SaveValue(true);
            Page.Control("Clear on Submit").Activate();
            Page.Control("Clear on Submit").SaveValue(true);
        }
        internal static void DisableInterfaces(UserContext userContext, ClientLogicalForm Page)
        {
            Page.Activate();
            Page.Control("Editable").Activate();
            Page.Control("Editable").SaveValue(false);
            Page.Control("Show").Activate();
            Page.Control("Show").SaveValue(false);
        }
    }
