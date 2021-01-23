    public class HttpPostedFileBaseConverter : CustomCreationConverter<HttpPostedFileBase>
    {
    	public override HttpPostedFileBase Create(Type objectType)
    	{
    		return new CustomHttpPostedFile();
    	}
    }
