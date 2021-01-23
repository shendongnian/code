    public interface IResourceCompiler
    {
        string UserImageCDNUrl {get;}
    }
    public abstract class WebConfigBase : IResourceCompiler
    {
        public virtual string UserImageCDNUrl {get { return string.empty;}}
    }
    public class WebConfig : WebConfigBase 
    {
        public override string  UserImageCDNUrl { return "whatever you want";} // or return base.UserImageCDNUrl ;
    }
