    Mapper.Initialize(cfg =>
    {
        cfg.AddCollectionMappers();
    
        cfg.SetGeneratePropertyMaps<GenerateEntityFrameworkPrimaryKeyPropertyMaps<DbContext>>();
  
        cfg.CreateMap<ArticleViewModel, Article>(MemberList.Source)
            .EqualityComparison((src, dst) => src.Id == dst.Id);
    
        cfg.CreateMap<DescriptionViewModel, Description>(MemberList.Source)
            .EqualityComparison((src, dst) => src.Id == dst.Id);
    }
    Mapper.AssertConfigurationIsValid();
