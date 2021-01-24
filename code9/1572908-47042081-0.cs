    Mapper.Initialize(cfg =>
    {
        cfg.AddCollectionMappers(); 
        cfg.CreateMap<DocumentAmountModel, InputDocumentData>()                    
           .ForMember(d => d.Amounts, o => o.MapFrom(s => s.Amounts));
        
       cfg.CreateMap<AmountModel, Amount>()
          .EqualityComparison((model, e) => model.Code == e.Code);
    });
