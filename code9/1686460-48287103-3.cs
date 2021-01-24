    public class PersistedGrantMapperProfile:Profile
    {
		/// <summary>
		/// <see cref="PersistedGrantMapperProfile">
		/// </see>
		/// </summary>
		public PersistedGrantMapperProfile()
		{
			CreateMap<PersistedGrantInfo, IdentityServer4.Models.PersistedGrant>(MemberList.Destination)
				.ReverseMap();
		}
	}
