    public class ProxyDocumentEntity : IDocumentEntity
	{
		    public dynamic Content { get; private set; }
		    public ProxyDocumentEntity(dynamic @content)
		    {
			    Content = @content;
		    }
		    public Guid Id
		    {
			    get { return Content.Id; }
			    set { Content.Id = value; }
		    }
	}
