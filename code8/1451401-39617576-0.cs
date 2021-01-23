    public interface IResourceCompiler
    {
        string UserImageCDNUrl {get;}
    }
    public abstract class WebConfigBase : IResourceCompiler
    {
        public abstract string UserImageCDNUrl {get;}
    }
    public class WebConfig : WebConfigBase 
    {
        public override string  UserImageCDNUrl { return "whatever you want";}
    }
