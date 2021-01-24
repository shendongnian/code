    public static class PersistedGrantMappers
	{
		internal static IMapper Mapper { get; }
		static PersistedGrantMappers()
		{
			Mapper = new MapperConfiguration(cfg => cfg.AddProfile<PersistedGrantMapperProfile>())
				.CreateMapper();
		}
		/// <summary>
		/// Maps an entity to a model.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		public static PersistedGrant ToModel(this PersistedGrantInfo entity)
		{
			return entity == null ? null : Mapper.Map<PersistedGrant>(entity);
		}
		/// <summary>
		/// Maps a model to an entity.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		public static PersistedGrantInfo ToEntity(this PersistedGrant model)
		{
			return model == null ? null : Mapper.Map<PersistedGrantInfo>(model);
		}
		/// <summary>
		/// Updates an entity from a model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="entity">The entity.</param>
		public static void UpdateEntity(this PersistedGrant model, PersistedGrantInfo entity)
		{
			Mapper.Map(model, entity);
		}
	}
