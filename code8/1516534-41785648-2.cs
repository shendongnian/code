    public class Tenant 
    {
	  // core things go here
	  public Extensions Extensions { get; }
    }
    public class Extensions : IEnumerable<IExtension>
    {
  	  private IList<IExtension> list = new List<IExtension();
	  private Tenant { get; set; }
	  public Extensions(Tenant tenant)
	  {
	    Tenant = tenant;
	  }
	  public void Add(IExtension extension)
	  {
	    extension.Tenant = Tenant;
	    list.Add(extension);
	  }
    }
    public interface IExtension
    {
	  Tenant { get; set; }
	  // shared interface of extensions if any can be abstracted
    }
    public interface ICoverPhotoExtension : IExtension
    {
	  Photo GetCoverPhoto();
    }
    public class FileCoverPhotoExtension : ICoverPhotoExtension 
    {
	  public Tenant { get; set; }
	  Photo GetCoverPhoto() { } // gets photo from file
    }
    public class BlogCoverPhotoExtension : ICoverPhotoExtension 
    {
	  public Tenant { get; set; }
	  Photo GetCoverPhoto() { } // gets photo from blog
    }
