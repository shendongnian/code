    public interface IMedia
    {
        public readonly IEnumerable<MediaResource> MediaResources {get; set;}
    }
    public interface IMediaResource<T> where T: class
    {
        public Type MediaId;
        public void SetMedia<T>(int mediaId);
    }
    public class MediaResource<T> : IMediaResource<T> //Container for a media resource
    {
        public Type mediaType { get; private set;}
        public int mediaId {get; private set;}
        public void SetMedia<T>(int mediaId)
        {
            this.mediaType = typeof(T);
            this.mediaId = mediaId;
        }
    }
    public class Media : IMedia
    {
        public readonly IEnumerable<MediaResource> MediaResources {get; set;}
    }
