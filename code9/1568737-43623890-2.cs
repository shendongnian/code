    public static StatisticsViewModel MapToView(StatisticsDto dto)
    {
         Mapper.Initialize(cfg => cfg.CreateMap<StatisticsDto, StatisticsViewModel>());
         var ViewModel = Mapper.Map<StatisticsViewModel>(dto);
    
         return viewModel;
    }
