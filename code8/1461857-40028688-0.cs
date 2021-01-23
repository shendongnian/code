    public class MyProfile : Profile
    {
    
    	protected override void Configure()
        {
    		CreateMap<Destinantion, Source>()
    			.ForMember(dest => dest.Description, opt => opt.ResolveUsing<CustomResolver>().FromMember(src => src.Code));
    	}
    }
    
    public class CustomResolver : IValueResolver
    {
    	public ResolutionResult Resolve(ResolutionResult source)
    	{
    		var code = (int)source.Value;
    
    		var tag = source.Context.Options.Items["Tag"].ToString();
    
    		var description = Dic.GetDescription(code, tag);
    
    		return source.New(description);
    	}
    }
