    public class Translator : MarkupExtension
    {
    const string ResourceId = "LDVELH_WPF.Resources.Strings";
    public Translator()
    {
    }
   
    public string Text
    {
        get;
        set;
    }
    override public object ProvideValue(IServiceProvider serviceProvider)
    {
        if (Text == null)
            return "";
        ResourceManager Resmgr = new ResourceManager(ResourceId
                            , typeof(Translator).GetTypeInfo().Assembly);
        return Resmgr.GetString(Text, GlobalCulture.Instance.Ci);
    }
    public string ProvideValue(string stringToTranslate)
    {
            Text = stringToTranslate;
            if (Text == null)
                return "";
            ResourceManager Resmgr = new ResourceManager(ResourceId
                                , typeof(Translator).GetTypeInfo().Assembly);
            return Resmgr.GetString(Text, GlobalCulture.Instance.Ci);
    }
    }
