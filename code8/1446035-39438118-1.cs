    Mapper.Initialize(cfg =>
        {
              cfg.CreateMap<Dish, DishViewModel>()
                    .ForMember(s => s.Ingredients, c => c.MapFrom(m => m.Ingredients));
    
               cfg.CreateMap<Ingredients, IngredientsViewModel>();
    
         });
