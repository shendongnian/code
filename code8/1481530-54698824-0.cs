`lang-cs
[Transaction(TransactionMode.ReadOnly)]
public class MyCommand: IExternalCommand 
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) {
    try 
    {
        //do stuff
    } catch (Exception exp) {
        CrashReporter.LogException(exp);
        throw;
    }
}
`
Then apply the same to any other entry points into your add-in such as `IExternalApplication.StartUp()`, `IExternalApplication.ShutDown()` etc..
