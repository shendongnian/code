	abstract class Media
	{
		public string Filename {get;set;}
		
		public virtual ICollection<Tag> Tags {get;set;}
	}
	
	public class Image : Media
	{
		public ImageFormat Format {get;set;}
		public int ResX {get;set;}
		public int ResY {get;set;}	// or whatever
	}
	
	public class Video : Media 
	{
		public VideoFormat Format {get;set;}
		public int Bitrate {get;set;}
	}
	
	
	
	public class Tag
	{
		public string Name {get;set;}
		
		public virtual ICollection<Media> Media {get;set;}
	}
