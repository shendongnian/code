    public ABCFacade(Ifacade iFacade)
    {
    LoadPlugin();
    _iFacade = iFacade; // Make sure the class instance that you want to create in the child class must have a [Export] tag, like we did in above.
    }
    Export(typeof(IProvider))]
    [ExportMetadata("ProviderName", "ABC")]
    public class Plugin : IProvider
    {
    private readonly IFacade _iFacade;
    [ImportingConstructor] // This tag will override the constructor.
    public Plugin(IFacade iFacade)
    {
      _iFacade = iFacade;
    }
    }
