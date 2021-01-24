    public class NullCheckResolver : IValueResolver<TSrc, TDest, TProp>
    {
    	public int Resolve(TSrc source, TDest destination, TProp member, ResolutionContext context)
    	{
            if (member.DateDeleted == null)
                return member;
            return null;
    	}
    }
    CreateMap<TSrc, TDest>().ForMember(dest => dest.MyOptionalProperty, opt => opt.ResolveUsing<NullCheckResolver>());
