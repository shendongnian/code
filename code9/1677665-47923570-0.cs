    public interface IResourceModel
    {
        IFiles Files { get; }
    }
    public interface IResourceModel<T> : IResourceModel
    {
        new T Files { get; set; }
    }
    public class Media : IResourceModel<MediaFiles>
    {
        public MediaFiles Files { get; set; }
        IFiles IResourceModel.Files => Files;
    }
    public class Image : IResourceModel<ImagesFiles>
    {
        public ImagesFiles Files { get; set; }
        IFiles IResourceModel.Files => Files;
    }
    public class Info : IResourceModel<InfoFiles>
    {
        public InfoFiles Files { get; set; }
        IFiles IResourceModel.Files => Files;
    }
    public interface IFiles {}
    public class MediaFiles : IFiles { }
    public class ImagesFiles : IFiles { }
    public class InfoFiles : IFiles { }
